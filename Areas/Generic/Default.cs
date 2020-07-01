using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.Generic
{
    public class Default
    {
        public PropertiesModel Properties;
        public Default() {
            Properties = new PropertiesModel();
        }    
        
        public void BindFiles()
        {
            if(Properties.CodeFile != null)
            {
                Properties.CodeFile = Activator.CreateInstance("NeuroSites", Properties.CodeFile);
                //Properties.CodeFile = Properties.CodeFile.Unwrap();
            }
        }
    }
}