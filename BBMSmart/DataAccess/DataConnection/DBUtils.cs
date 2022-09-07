using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAllTool.DataAccess.DataConnection
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "10.80.7.82";
            int port = 3306;
            string database = "bibomart";
            string username = "bibomart";
            string password = "bbmnanow321@23";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
