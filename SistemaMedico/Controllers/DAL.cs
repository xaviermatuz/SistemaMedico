using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMedico.Controllers
{
    public class DAL
    {
        DataSet ds;
        SqlDataAdapter da;

        public static SqlConnection connect()
        {
            //Reading the connection string from web.config    
            string Name = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            //Passing the string in sqlconnection.    
            SqlConnection con = new SqlConnection(Name);
            //Check wheather the connection is close or not if open close it else open it    
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            else
            {

                con.Open();
            }
            return con;

        }
        //Creating a method which accept any type of query from controller to execute and give result.    
        //result kept in datatable and send back to the controller.    
        public DataTable MyMethod(string Query)
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(Query, DAL.connect());

            da.Fill(dt);
            List<SelectListItem> list = new List<SelectListItem>();
            return dt;

        }
    }
}