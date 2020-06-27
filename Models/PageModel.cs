using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Models
{
    public class PageModel
    {
        PageModel() {
            Modules = new List<string>();
        }
        /// <summary>
        /// This is the name of the module (Areas Folder)
        /// </summary>
        public List<string> Modules { get; set; }
    }
}