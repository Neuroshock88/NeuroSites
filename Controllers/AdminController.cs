using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeuroSites;
using System.Data;

namespace NeuroSites.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string userNam, string password)
        {
            App_Start.Common cmn = new App_Start.Common();

            //DataSet loginData = cmn.ExecuteQueryWithResults("EXEC CheckLogin " + )
            return View();
        }
    }
}