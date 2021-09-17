using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Management_System.Models;

namespace Training_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "checkUsers";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("username", user.UserName);
            cmd.Parameters.AddWithValue("password", user.Password);



            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            if(sdr.HasRows)
            {
                while(sdr.Read())
                {

                    string temprole = sdr["role"].ToString();

                    if (temprole == "Trainer")
                    {
                        return RedirectToAction("Index", "Trainer");
                    }
                    else if (temprole == "TrainingManager")
                    {
                        return RedirectToAction("Index", "TrainingManager");
                    }
                }
               
            }

            return View();
        }


    }
}