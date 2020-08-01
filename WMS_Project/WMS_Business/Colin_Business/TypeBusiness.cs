using System;
using System.Collections.Generic;
using System.Text;
using WMS_DataAccess.Colin_DataAccess;
using WMS_Models.Pro_Models;

namespace WMS_Business.Colin_Business
{
    public class TypeBusiness
    {
        SqlDbHelper dal = new SqlDbHelper();
        //添加
        public int Add<T>(T t) where T : class, new()
        {
            return dal.Add<T>(t);
        }
        //显示
        public List<T> Show<T>() where T : class, new()
        {
            return dal.Show<T>();
        }
        //删除
        public int Delete<T>(T t) where T : class, new()
        {
            return dal.Delete<T>(t);
        }
        //修改
        public int Update<T>(T t) where T : class, new()
        {
            return dal.Update<T>(t);
        }



    }
}
