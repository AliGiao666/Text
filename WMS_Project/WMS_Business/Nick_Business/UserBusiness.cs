using System;
using System.Collections.Generic;
using System.Text;
using WMS_DataAccess.Nick_DataAccess;
using WMS_Models.Pro_Models;

namespace WMS_Business.Nick_Business
{
    public class UserBusiness
    {
        NickDbhelper dal = new NickDbhelper();

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


        //查询
        public List<UserInfoModel> Search(UserInfoModel m)
        {
            string sql = "select * from UserInfo where 1=1 ";
            if (!string.IsNullOrEmpty(m.UserName))
            {
                sql += $" and UserName = @UserName ";
            }
            if (m.Department != 0)
            {
                sql += $" and Department = @Department ";
            }
            if (m.role != 0)
            {
                sql += $" and role = @role ";
            }
            if (!string.IsNullOrEmpty(m.UserNumber))
            {
                sql += $" and UserNumber = @UserNumber ";
            }

            return dal.Search<UserInfoModel, UserInfoModel>(sql, m);
        }

    }
}
