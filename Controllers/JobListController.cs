using Ef_codefirst_app.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ef_codefirst_app.Controllers
{
    public class JobListController : Controller
    {
        public JobListController()
        {

        }
        private DBContext dbContext = new DBContext();
        // GET: JobList with stored procedure
        public ActionResult Index()
        {
            //using (var context = new DBContext())
            //{
            //    var data = context.Database.SqlQuery<JobList>("spGetAllJobList").ToList();
            //}
            var list = dbContext.Database.SqlQuery<JobList>("spGetAllJobList").ToList();
            return View(list);
        }
        public ActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddJob(JobList list)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var jobRole = new SqlParameter("@JobRole", list.JobRole);
                    var CompanyName = new SqlParameter("@CompanyName", list.CompanyName);
                    var Description = new SqlParameter("@Description", list.Description);
                    var Skill = new SqlParameter("@Skill", list.Skill);
                    var Timestamp = new SqlParameter("@Timestamp", list.Timestamp);
                    var query = dbContext.Database.ExecuteSqlCommand("spAddJobList @JobRole,@CompanyName, @Description,@Skill,@Timestamp", new SqlParameter("JobRole", list.JobRole), new SqlParameter("CompanyName", list.CompanyName), new SqlParameter("Description", list.Description), new SqlParameter("Skill", list.Skill), new SqlParameter("Timestamp", list.Timestamp));
                    ViewBag.message = "Data saved, Success!";
                }
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult SaveData(JobList list)
        {
            var data = dbContext.Database.ExecuteSqlCommand("SP_update_joblist @JobRole,@CompanyName, @Description,@Skill,@Timestamp,@ID", new SqlParameter("JobRole", list.JobRole), new SqlParameter("CompanyName", list.CompanyName), new SqlParameter("Description", list.Description), new SqlParameter("Skill", list.Skill), new SqlParameter("Timestamp", list.Timestamp), new SqlParameter("ID", list.ID));
            return RedirectToAction("index");
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult EditJob(int id)
        {
            //var data;
            try
            {
                //dbContext.Database.ExecuteSqlCommand("SP_update_joblist @JobRole,@CompanyName, @Description,@Skill,@Timestamp,@ID", new SqlParameter("JobRole", list.JobRole));
                //data = dbContext.jobList.Find(id);
                //return View(data);
                var data = dbContext.jobList.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(dbContext.jobList.Find(id));
        }
        [HttpGet]
        public ActionResult DeleteJob(int id)
        {
            try
            {
                var list = dbContext.Database.ExecuteSqlCommand("sp_del_joblist @id", new SqlParameter("id", id));
                //var data = dbContext.jobList.Remove(list); 
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}