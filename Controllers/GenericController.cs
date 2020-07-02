using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeuroSites.Controllers
{
    public class GenericController : Controller
    {
        // GET: Generic
        public ActionResult Index(string viewName, dynamic model)
        {
            
            if(!string.IsNullOrEmpty(Models.PagesModel.Module) && Models.PagesModel.Model != null)
            {
                return View(viewName, model);
            }
            return null;
        }
    }
}