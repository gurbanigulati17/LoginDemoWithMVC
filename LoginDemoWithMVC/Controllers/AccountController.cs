using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using LoginDemoWithMVC.Models;
using System.Data.SqlClient;


//reference the model class here using using keyword

namespace LoginDemoWithMVC.Controllers
{
    // Step 2: Create an empty MVC5 Controller in Controller folder

    public class AccountController : Controller
    {


        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        // GET: Account
        //Change the ACtion name from Index to Login
        [HttpGet]
        //By default it is Http get method.
        public ActionResult Login()
        {
            return View();
        }



        //Create a Connection String
        void connectionString()
        {
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\geetg\OneDrive\Documents\LoginCredentialDB.mdf;Integrated Security=True;Connect Timeout=30";
        }




        [HttpPost]
        //Making a function when user clicks on the Action button Login
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Login where username ='"+acc.name+"' and password='"+acc.password+"'";
           
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }

            

        }
    }
}