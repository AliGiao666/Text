using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WMS_DataAccess.Ryan_DataAccess
{
    public abstract class RyanAbstrtionDAL
    {
        private static string con = "Data Source=192.168.43.236;Initial Catalog=WMSDB;Persist Security Info=True;User ID=sa;password=1234";

        public static IDbConnection GetSql()
        {
            IDbConnection conn = new SqlConnection(con);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
