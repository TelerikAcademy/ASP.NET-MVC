namespace DatabaseChange.Migrations
{
    using DatabaseChange.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseChange.Models.JobsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseChange.Models.JobsDbContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                context.Jobs.Add(new JobInfo
                {
                    Name = "Job " + i,
                    Status = "Pending",
                    LastExecutionDate = DateTime.Now
                });
            }
        }
    }
}
