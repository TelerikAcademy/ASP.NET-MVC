using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseChange.Models
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<JobInfo> Jobs { get; set; }
    }
}