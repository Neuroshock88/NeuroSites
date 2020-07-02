using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Models
{
    public static class PagesModel
    {

        /// <summary>
        /// This is the name of the module (Areas Folder)
        /// </summary>
        public static List<string> Modules;
        public static List<dynamic> Models;
        public static dynamic ActiveModel;
    }
}