using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using NeuroSites.Models;
using System.Runtime.Remoting.Messaging;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Net;


namespace NeuroSites.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            if (Classes.StaticFunctions.IsDevDomain())
            {
                Classes.StaticFunctions.Website = "neuroshock88.com";
            }
            else
            {
                if (HttpContext.Request != null)
                {
                    string[] themes = Directory.GetDirectories(Server.MapPath("~/Content/Data/Themes/"));
                    if (themes != null)
                    {
                        foreach (string theme in themes)
                        {
                            string[] splitter = theme.Split('\\');
                            string folderName = splitter[splitter.Length - 1];
                            if (HttpContext.Request.Url.Host.ToLower().IndexOf(folderName.ToLower()) >= 0)
                            {
                                Classes.StaticFunctions.Website = folderName;
                                break;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            string area = "";
            string url = System.Web.HttpContext.Current.Request.RawUrl.Replace("http://", "").Replace("https://", "").Replace("Default/Index", "");

            bool hasSlug = (url.IndexOf("/") < url.Length && url != "/" && (url.Contains("#") == false));
            string json = "";
            if (hasSlug == false)
            {
                //load the home page template
                if (Classes.StaticFunctions.Website != null)
                {
                    if (!string.IsNullOrEmpty(Classes.StaticFunctions.Website))
                    { 
                        json = new StreamReader(Server.MapPath("/Content/Data/Themes/" + Classes.StaticFunctions.Website + "/Pages/home.json")).ReadToEnd();
                    }
                }
            }
            else
            {
                //load the back page template
                if (url.Substring(url.Length - 1, 1) != "/")
                {
                    if (url.IndexOf("/") + 2 < url.Length)
                    {
                        area = url.Replace("/", "");
                        if (!string.IsNullOrEmpty(area))
                        {
                            if(System.IO.File.Exists(Server.MapPath("/Content/PageTemplates/" + area + ".json")))
                            {
                                json = new StreamReader(Server.MapPath("/Content/PageTemplates/" + area + ".json")).ReadToEnd();
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(json))
            {
                Dictionary<string, List<string>> modulesList = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
                List<String> modules = new List<string>();
                modulesList.TryGetValue("Modules", out modules);
                if (modulesList != null)
                {
                    if (modulesList.Count > 0)
                    {
                        PagesModel.Models = new List<dynamic>();
                        PagesModel.Modules = new List<string>();
                        List<ViewResult> views = new List<ViewResult>();
                        foreach (string mod in modules)
                        {
                            PagesModel.Modules.Add("~/Areas/" + mod + "/Views/Index.cshtml");
                            
                        }

                        //return View(pages);
                    }
                }
            }
            //return View("~/Areas/Generic/Views/Index.cshtml", new NeuroSites.Areas.Generic.Default());
            return View();
        }
    }
}