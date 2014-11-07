using DatabaseChange.Hubs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DatabaseChange.Models
{
    public class JobInfo
    {
        [Key]
        public int JobID { get; set; }

        public string Name { get; set; }

        public DateTime LastExecutionDate { get; set; }

        public string Status { get; set; }
    }

    public class JobInfoRepository
    {

        public IEnumerable<JobInfo> GetData()
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [JobID],[Name],[LastExecutionDate],[Status]
               FROM [dbo].[JobInfoes]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new JobInfo()
                            {
                                JobID = x.GetInt32(0),
                                Name = x.GetString(1),
                                LastExecutionDate = x.GetDateTime(2),
                                Status = x.GetString(3)
                            }).ToList();
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            JobHub.Show();
        }
    }
}