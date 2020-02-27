using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Models
{
    public class CompanyModel
    {

        public CompanyModel() {
            
        }

        /// <summary>
        /// gets or sets the company ID
        /// </summary>
        public int CompanyID { get; set; }

        /// <summary>
        /// gets or sets the company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// gets or sets the company's web URL
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// gets or sets the company's Address
        /// </summary>
        public AddressModel Address { get; set; }


    }
}