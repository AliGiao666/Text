using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace WMS_DataAccess.Ryan_DataAccess
{
    public class RyanDBhelper : IRyanIDA
    {
        private IDbConnection conn = RyanAbstrtionDAL.GetSql();

        

        //显示
        public List<T> Show<T>(string sql) where T : class, new()
        {
            return conn.Query<T>(sql).ToList();
        
        }

      
    }
}
