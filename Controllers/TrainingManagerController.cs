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
    public class TrainingManagerController : Controller
    {
        // GET: TrainingManager
        public ActionResult Index()
        {
            return View();
        }


        public List<TrainingDetail> TrainingDetailsList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "selectTrainingDetails";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader sqldatareader = cmd.ExecuteReader();
            List<TrainingDetail> TrainingDetailslist = new List<TrainingDetail>();
            if (sqldatareader.HasRows)
            {
                while (sqldatareader.Read())
                {
                    var TrainingDetailsobj = new TrainingDetail();
                    TrainingDetailsobj.TrainingId = Convert.ToInt32(sqldatareader["TrainingId"]);
                    TrainingDetailsobj.TrainingName = sqldatareader["TrainingName"].ToString();
                    TrainingDetailsobj.Technology = sqldatareader["Technology"].ToString();
                    TrainingDetailsobj.ExpectedStartDate = Convert.ToDateTime(sqldatareader["ExpectedStartDate"]);
                    TrainingDetailsobj.ExpectedDurationInHours = Convert.ToInt32(sqldatareader["ExpectedDurationInHours"]);
                    TrainingDetailsobj.TotalDuration = sqldatareader["TotalDuration"].ToString();
                    TrainingDetailsobj.ExpectedEndDate = Convert.ToDateTime(sqldatareader["ExpectedEndDate"]);
                    TrainingDetailsobj.TrainingType = sqldatareader["TrainingType"].ToString();

                    TrainingDetailslist.Add(TrainingDetailsobj);

                }
            }

            return TrainingDetailslist;
        }

        [HttpGet]
        public ActionResult GetTrainingDetails()
        {

            return View(TrainingDetailsList());
        }

        [HttpGet]
        public ActionResult insertTrainingDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertTrainingDetails(TrainingDetail TrainingDetails)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "insertTrainingDetails";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("trainingname", TrainingDetails.TrainingName);
            cmd.Parameters.AddWithValue("technology", TrainingDetails.Technology);
            cmd.Parameters.AddWithValue("startdate", TrainingDetails.ExpectedStartDate);
            cmd.Parameters.AddWithValue("durationinhours", TrainingDetails.ExpectedDurationInHours);
            cmd.Parameters.AddWithValue("TotalDuration", TrainingDetails.TotalDuration);
            cmd.Parameters.AddWithValue("enddate", TrainingDetails.ExpectedEndDate);
            cmd.Parameters.AddWithValue("trainingtype", TrainingDetails.TrainingType);
            conn.Open();

            cmd.ExecuteNonQuery();

            return View("GetTrainingDetails", TrainingDetailsList());
        }

        [HttpGet]
        public ActionResult updateTrainingDetails(int Id)
        {
            TrainingDetail TrainingDetailsobj = null;
            List<TrainingDetail> TrainingDetailslist = TrainingDetailsList();
            foreach (var i in TrainingDetailslist)
            {
                if (i.TrainingId == Id)
                {
                    TrainingDetailsobj = i;
                }
            }
            return View(TrainingDetailsobj);
        }


        [HttpPost]
        public ActionResult updateTrainingDetails(TrainingDetail TrainingDetails)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "updateTrainingDetails";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TrainingId", TrainingDetails.TrainingId);
            cmd.Parameters.AddWithValue("trainingname", TrainingDetails.TrainingName);
            cmd.Parameters.AddWithValue("technology", TrainingDetails.Technology);
            cmd.Parameters.AddWithValue("startdate", TrainingDetails.ExpectedStartDate);
            cmd.Parameters.AddWithValue("durationinhours", TrainingDetails.ExpectedDurationInHours);
            cmd.Parameters.AddWithValue("TotalDuration", TrainingDetails.TotalDuration);
            cmd.Parameters.AddWithValue("enddate", TrainingDetails.ExpectedEndDate);
            cmd.Parameters.AddWithValue("trainingtype", TrainingDetails.TrainingType);
            conn.Open();

            cmd.ExecuteNonQuery();

            return View("GetTrainingDetails", TrainingDetailsList());
        }


        [HttpGet]
        public ActionResult DetailsTrainingDetails(int Id)
        {
            TrainingDetail TrainingDetailsobj = null;
            List<TrainingDetail> TrainingDetailslist = TrainingDetailsList();
            foreach (var i in TrainingDetailslist)
            {
                if (i.TrainingId == Id)
                {
                    TrainingDetailsobj = i;
                }
            }
            return View(TrainingDetailsobj);
        }

        [HttpGet]
        public ActionResult deleteTrainingDetails(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "deleteTrainingDetails";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TrainingId", Id);
            conn.Open();
            try
            { 
                cmd.ExecuteNonQuery();
                return View("GetTrainingDetails", TrainingDetailsList());
            }
            catch
            {
                return View();
            }
        }


        public List<Trainee> TraineesList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "selectTrainees";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader sqldatareader = cmd.ExecuteReader();
            List<Trainee> Traineeslist = new List<Trainee>();
            if (sqldatareader.HasRows)
            {
                while (sqldatareader.Read())
                {
                    var Traineesobj = new Trainee();
                    Traineesobj.EmpId = Convert.ToInt32(sqldatareader["EmpId"]);
                    Traineesobj.CertificationType = sqldatareader["CertificationType"].ToString();
                    Traineesobj.TrainingType = sqldatareader["TrainingType"].ToString();
                    Traineesobj.TrainingFrom = Convert.ToDateTime(sqldatareader["TrainingFrom"]);
                    Traineesobj.Score = Convert.ToInt32(sqldatareader["Score"]);
                    Traineesobj.IsCertified = Convert.ToBoolean(sqldatareader["IsCertified"]);
                    Traineesobj.NumberOfAttempt = Convert.ToInt32(sqldatareader["NumberOfAttempt"]);
                    Traineesobj.TrainingId = Convert.ToInt32(sqldatareader["TrainingId"]);
                    Traineesobj.TrainingName = sqldatareader["TrainingName"].ToString();
                    

                    Traineeslist.Add(Traineesobj);

                }
            }

            return Traineeslist;
        }


        [HttpGet]
        public ActionResult GetTrainees()
        {

            return View(TraineesList());
        }

        [HttpGet]
        public ActionResult insertTrainees()
        {
            return View();
        }


        [HttpPost]
        public ActionResult insertTrainees(Trainee Trainees)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "insertTrainees";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CertificationType", Trainees.CertificationType);
            cmd.Parameters.AddWithValue("TrainingType", Trainees.TrainingType);
            cmd.Parameters.AddWithValue("TrainingFrom", Trainees.TrainingFrom);
            cmd.Parameters.AddWithValue("Score", Trainees.Score);
            cmd.Parameters.AddWithValue("IsCertified", Trainees.IsCertified);
            cmd.Parameters.AddWithValue("NumberOfAttempt", Trainees.NumberOfAttempt);
            cmd.Parameters.AddWithValue("TrainingId", Trainees.TrainingId);
            conn.Open();

            cmd.ExecuteNonQuery();

            return View("GetTrainees", TraineesList());
        }


        [HttpGet]
        public ActionResult updateTrainees(int Id)
        {
            Trainee Traineesobj = null;
            List<Trainee> Traineeslist = TraineesList();
            foreach (var i in Traineeslist)
            {
                if (i.EmpId == Id)
                {
                    Traineesobj = i;
                }
            }
            return View(Traineesobj);
        }


        [HttpPost]
        public ActionResult updateTrainees(Trainee Trainees)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "updateTrainees";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpId", Trainees.EmpId);
            cmd.Parameters.AddWithValue("CertificationType", Trainees.CertificationType);
            cmd.Parameters.AddWithValue("TrainingType", Trainees.TrainingType);
            cmd.Parameters.AddWithValue("TrainingFrom", Trainees.TrainingFrom);
            cmd.Parameters.AddWithValue("Score", Trainees.Score);
            cmd.Parameters.AddWithValue("IsCertified", Trainees.IsCertified);
            cmd.Parameters.AddWithValue("NumberOfAttempt", Trainees.NumberOfAttempt);
            cmd.Parameters.AddWithValue("TrainingId", Trainees.TrainingId);
            conn.Open();

            cmd.ExecuteNonQuery();

            return View("GetTrainees", TraineesList());
        }


        [HttpGet]
        public ActionResult deleteTrainees(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TrainingDbEntities"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "deleteTrainees";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", Id);
            conn.Open();
            cmd.ExecuteNonQuery();

            return View("GetTrainees", TraineesList());
        }



        [HttpGet]
        public ActionResult detailsTraniees(int Id)
        {
            Trainee Traineesobj = null;
            List<Trainee> Traineeslist = TraineesList();
            foreach (var i in Traineeslist)
            {
                if (i.EmpId == Id)
                {
                    Traineesobj = i;
                }
            }
            return View(Traineesobj);
        }



    }
}