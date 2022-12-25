using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_05.DAL
{
    public class SQLQuery
    {
        // private static string connectionString = ConfigurationManager.AppSettings//["ConnectionString"];
        private static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\SQLEXPRESS";
        public delegate void SetDataReader_dg(SqlDataReader reader);
        public delegate object SetResultDataReader_dg(SqlDataReader reader);

        // explanation - this function is a generic function that can be used for any query that do not return a result
        public static void runCommand(string sqlQ, SetDataReader_dg setDataReader)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQ, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        setDataReader(reader);

                    }
                }
            }
        }

        // explanation - this function is for select query that return one result
        public static object RunCommandResult(string sqlQ, SetResultDataReader_dg setQueryResult)
        {
            object ret = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQ;

                
         
                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ret = setQueryResult(reader);
                    }

                }
            }
            return ret;
        }

        public static void RunNonQuery(string sqlQ)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = sqlQ;

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Optional - get the result into var called affectedRows for Debugging or validation purposes.
                }
            }

        }
    }
}
