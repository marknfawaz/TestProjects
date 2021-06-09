using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BuildableWebApi.DataAccess
{
    public class SqlDbAccess
    {
        public string GetData()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SqlDbAccess"].ConnectionString;
            var dataResult = new List<string>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand("SELECT * FROM Table", sqlConnection))
                {
                    sqlConnection.Open();


                    var sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        dataResult.Add(sqlDataReader["ColumnName"].ToString());
                    }

                    sqlConnection.Close();
                }
            }
            return String.Join(",", dataResult);
        }
    }
}