using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Ef_codefirst_app.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name= sqlServerStr")
        {
        }
        // Get job list with JobList table
        public DbSet<JobList> jobList { get; set; }

    }
}