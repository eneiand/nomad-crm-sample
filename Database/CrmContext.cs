using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;

namespace YetAnotherCRM
{
    public class CrmContext : DbContext
    {
        private static readonly Lazy<string> s_DeploymentConnectionString = new Lazy<string>(CreateEmptyDb);
        
        public CrmContext()
            : base(new SqlConnection(s_DeploymentConnectionString.Value), true)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Note> Notes { get; set; }

        private static string GetConnectionStringWithDatabaseApplied(string databaseName)
        {
            return new SqlConnectionStringBuilder("Server=some.server.com;")
            {
                UserID = "", //<user with create privelleges>,
                Password = "", //pasword
                InitialCatalog = databaseName
            }.ConnectionString;
        }

        private static string CreateEmptyDb()
        {
            var databaseName = Environment.MachineName + "_" + Path.GetRandomFileName().Substring(0, 8);

            using (SqlConnection myConn = new SqlConnection(GetConnectionStringWithDatabaseApplied("master")))
            {
                using (SqlCommand myCommand = new SqlCommand(String.Format("CREATE DATABASE [{0}]", databaseName), myConn))
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                }
            }

            return GetConnectionStringWithDatabaseApplied(databaseName);
        }
    }
}
