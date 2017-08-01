using System;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;

namespace Eventador.Tests
{
    [Ignore("Here be dragons")]
    public class DbReset
    {
        [Test]
        public void Reset()
        {
            const string sqlCommandText = @"
            ALTER DATABASE [Eventador.EventadorContext] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE [Eventador.EventadorContext]";

            using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Integrated Security=True; MultipleActiveResultSets=True"))
            {
                connection.Open();
                var sqlCommand = new SqlCommand(sqlCommandText, connection);

                //GetDatabaseNames(connection);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private static void GetDatabaseNames(SqlConnection connection)
        {
            var databases = connection.GetSchema("Databases");

            //close connection
            connection.Close();

            //add to list
            foreach (DataRow row in databases.Rows)
            {
                Console.WriteLine(row["database_name"]);
            }
        }
    }
}