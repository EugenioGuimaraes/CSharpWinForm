using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.DataBase
{
    public abstract class Db_Connection
    {
        private readonly string connectionString;
        
        public Db_Connection()
        {
            connectionString = "Server=(local); DataBase=NorthwindStore; Integraded security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
