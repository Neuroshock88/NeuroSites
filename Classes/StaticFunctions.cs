using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Classes
{
    public static class StaticFunctions
    {
        /// <summary>
        /// Gets or Sets the Website Variable
        /// </summary>
        public static string Website { get; set; }

        public static bool IsDevDomain() 
        {
            if (HttpContext.Current.Request.Url.Port == 44317) 
            {
                return true;    
            }
            return false;
        }

    }
}