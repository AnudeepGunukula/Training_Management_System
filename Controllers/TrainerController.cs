using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Training_Management_System.Models;
namespace Training_Management_System.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTrainingDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "selecttrainingDetails";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader sqldatareader = cmd.ExecuteReader();
            List<TrainingDetail> traininglist = new List<TrainingDetail>();
            if(sqldatareader.HasRows)
            {
                while(sqldatareader.Read())
                {
                    var trainingobj = new TrainingDetail();
                    trainingobj.TrainingId = Convert.ToInt32(sqldatareader["TrainingId"]);
                    trainingobj.TrainingName = sqldatareader["TrainingName"].ToString();
                    trainingobj.Technology = sqldatareader["Technology"].ToString();
                    trainingobj.ExpectedStartDate = Convert.ToDateTime(sqldatareader["ExpectedStartDate"]);
                    trainingobj.ExpectedDurationInHours = Convert.ToInt32(sqldatareader["ExpectedDurationInHours"]);
                    trainingobj.TotalDuration = sqldatareader["TotalDuration"].ToString();
                    trainingobj.ExpectedEndDate = Convert.ToDateTime(sqldatareader["ExpectedEndDate"]);
                    trainingobj.TrainingType = sqldatareader["TrainingType"].ToString();
                    traininglist.Add(trainingobj);

                }
            }

            return View(traininglist);
        }

        public List<Attendence> AttendenceList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "selectAttendences";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader sqldatareader = cmd.ExecuteReader();
            List<Attendence> Attendencelist = new List<Attendence>();
            if (sqldatareader.HasRows)
            {
                while (sqldatareader.Read())
                {
                    var attendenceobj = new Attendence();
                    attendenceobj.Id = Convert.ToInt32(sqldatareader["Id"]);
                    attendenceobj.TraineeName = sqldatareader["TraineeName"].ToString();
                    attendenceobj.TrainingName = sqldatareader["TrainingName"].ToString();
                    attendenceobj.Attendance = Convert.ToBoolean(sqldatareader["Attendance"]);
                    attendenceobj.Date = Convert.ToDateTime(sqldatareader["Date"]);
                    attendenceobj.EmpId = Convert.ToInt32(sqldatareader["EmpId"]);

                    Attendencelist.Add(attendenceobj);

                }
            }

            return Attendencelist;
        }

        [HttpGet]
        public ActionResult GetAttendence()
        {
           
            return View(AttendenceList());
        }

        [HttpGet]
        public ActionResult InsertAttendence()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InsertAttendence(Attendence attendence)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "InsertAttendences";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TraineeName", attendence.TraineeName);
            cmd.Parameters.AddWithValue("TrainingName", attendence.TrainingName);
            cmd.Parameters.AddWithValue("Attendance", attendence.Attendance);
            cmd.Parameters.AddWithValue("Date", attendence.Date);
            cmd.Parameters.AddWithValue("EmpId", attendence.EmpId);
            conn.Open();

            cmd.ExecuteNonQuery();

            return View("GetAttendence",AttendenceList());
        }




        [HttpGet]
        public ActionResult UpdateAttendence(int Id)
        {
            Attendence attendenceobj=null;
            List<Attendence> attendencelist = AttendenceList();
            foreach(var i in attendencelist)
            {
                if(i.Id==Id)
                {
                    attendenceobj = i;
                }
            }
            return View(attendenceobj);
        }

        [HttpPost]
        public ActionResult UpdateAttendence(Attendence attendence)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "UpdateAttendences";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", attendence.Id);
            cmd.Parameters.AddWithValue("TraineeName", attendence.TraineeName);
            cmd.Parameters.AddWithValue("TrainingName", attendence.TrainingName);
            cmd.Parameters.AddWithValue("Attendance", attendence.Attendance);
            cmd.Parameters.AddWithValue("Date", attendence.Date);
            cmd.Parameters.AddWithValue("EmpId", attendence.EmpId);
            conn.Open();

            cmd.ExecuteNonQuery();

            return View("GetAttendence", AttendenceList());
        }


        [HttpGet]
        public ActionResult DeleteAttendence(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "DeleteAttendences";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            conn.Open();
            cmd.ExecuteNonQuery();

            return View("GetAttendence", AttendenceList());
        }
       
      
        [HttpGet]
        public ActionResult DetailsAttendence(int Id)
        {
            Attendence attendenceobj = null;
            List<Attendence> attendencelist = AttendenceList();
            foreach (var i in attendencelist)
            {
                if (i.Id == Id)
                {
                    attendenceobj = i;
                }
            }
            return View(attendenceobj);
        }

    }


}
