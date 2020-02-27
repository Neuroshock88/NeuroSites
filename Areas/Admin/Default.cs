using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NeuroSites.App_Start;
using System.Net;

namespace NeuroSites.Areas.Admin
{
    public class Default
    {
        public PropertiesModel Properties = new PropertiesModel();
        private Common common = new Common();

        private void LoadHomePageContent() {

            DataSet homeData = common.ExecuteQueryWithResults("SELECT * From HomePageContent Where CompanyID = ");
            if(homeData != null)
            {
                if(homeData.Tables != null)
                {
                    if(homeData.Tables.Count >= 1)
                    {
                        if (homeData.Tables[0].Rows != null)
                        {
                            if (homeData.Tables[0].Rows.Count >= 1)
                            {
                                if (homeData.Tables[0].Columns != null)
                                {
                                    if (homeData.Tables[0].Columns.Count >= 1)
                                    {
                                        foreach (DataColumn col in homeData.Tables[0].Columns)
                                        {
                                            if (col.ColumnName.ToLower().Contains("slot"))
                                            {
                                                List<string> newData = new List<string>();
                                                newData.Add(homeData.Tables[0].Rows[0][col.ColumnName].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}