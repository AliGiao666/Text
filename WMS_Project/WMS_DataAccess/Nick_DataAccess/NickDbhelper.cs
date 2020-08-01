using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WMS_DataAccess.Nick_DataAccess
{
   public  class NickDbhelper
    {
        private IDbConnection con = NickAbstrtionDAL.GetSql();



        //反射添加 
        public int Add<T>(T t) where T : class, new()
        {
            string sql = "";
            string TableName = "";
            string FileName = "";
            string Values = "";
            Type type = t.GetType();
            PropertyInfo[] infos = type.GetProperties();
            TableName = type.Name.Replace("Model", "");
            for (int i = 0; i < infos.Length; i++)
            {
                if (!infos[i].Name.ToLower().Contains("id") && infos[i].GetValue(t) != null)
                {
                    if (i + 1 == infos.Length)
                    {
                        FileName += infos[i].Name;
                        Values += "'" + infos[i].GetValue(t).ToString() + "'";
                    }
                    else
                    {
                        FileName += infos[i].Name + ",";
                        Values += "'" + infos[i].GetValue(t).ToString() + "',";
                    }
                }
            }
            sql = " insert into [" + TableName + "](" + FileName + ") values(" + Values + ") ";
            return con.Execute(sql);
        }

        //删除
        public int Deletes(string sql)
        {
            return con.Execute(sql);
        }

        //反射删除
        public int Delete<T>(T t) where T : class, new()
        {
            Type type = t.GetType();
            string TableName = "";
            TableName = type.Name.Replace("Model", "");
            PropertyInfo[] property = type.GetProperties();
            string sql = $"delete from {TableName}";
            foreach (PropertyInfo item in property)
            {
                if (!string.IsNullOrEmpty(item.GetValue(t).ToString()))
                {
                    sql += $" where {item.Name} = '{item.GetValue(t)}'";
                }
            }

            return con.Execute(sql);
        }

        //查询
        public List<T> Search<T, M>(string sql, M m)
            where T : class
            where M : class, new()
        {
            return con.Query<T>(sql, m).ToList();
        }
        //反射显示
        public List<T> Show<T>() where T : class, new()
        {
            Type type = typeof(T);
            string sqls = "";
            string TableName = "";
            TableName = type.Name.Replace("Model", "");
            sqls = $"select * from {TableName}";
            return con.Query<T>(sqls).ToList();
        }
        //显示
        public List<T> Shows<T>(string sql) where T : class, new()
        {
            return con.Query<T>(sql).ToList();
        }
        //修改
        public int Updates(string sql)
        {
            return con.Execute(sql);
        }
        //反射修改
        public int Update<T>(T t) where T : class, new()
        {
            Type type = t.GetType();//获取类型
            PropertyInfo[] pro = type.GetProperties();//获取属性
            string TableName = "";
            TableName = type.Name.Replace("Model", "");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"update {TableName} set ");
            StringBuilder stringBuilder1 = new StringBuilder();
            string where = "";
            //拼接要修改的字段
            foreach (var item in pro)
            {
                if (item.GetValue(t) != null)//没有传值的不拼接到sql
                {
                    stringBuilder1.Append($"{item.Name}=N'{item.GetValue(t)}',");//字段名并数值
                }
            }
            //拼接id条件
            foreach (var item in pro)
            {
                where = $" where {item.Name}= N'{item.GetValue(t)}'";
                break;
            }
            string sql = stringBuilder.ToString() + stringBuilder1.ToString().Substring(0, stringBuilder1.Length - 1) + where;
            return con.Execute(sql);
        }
    }
}
