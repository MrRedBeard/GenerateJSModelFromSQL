using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateJSModelFromSQL
{
    public class clsGetDatabases
    {
        public List<string> GetDatabases(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            List<string> Databases = new List<string>();
            DataTable dt = new DataTable();

            con.Open();
            DataTable tblDatabases = con.GetSchema("Databases");
            con.Close();

            foreach (DataRow row in tblDatabases.Rows)
            {
                string DatabaseName = row[0].ToString();
                Databases.Add(DatabaseName);
            }

            return Databases;
        }
            
    }
}
