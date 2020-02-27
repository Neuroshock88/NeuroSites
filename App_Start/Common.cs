using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace NeuroSites.App_Start
{
    public class Common
    {
        SqlConnection con;

        public Common() {
            con = new SqlConnection();
            con.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        }

        public DataSet ExecuteQueryWithResults(string query)
        {
            DataSet ret = new DataSet();
            if (!string.IsNullOrEmpty(query))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                adapter.SelectCommand = cmd;
                adapter.Fill(ret);
                con.Close();
            }
            return ret;
        }

        public void ExecuteQueryNoResults(string query) {
            if (!string.IsNullOrEmpty(query))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

    }
}