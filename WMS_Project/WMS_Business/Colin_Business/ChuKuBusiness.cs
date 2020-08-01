
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS_DataAccess.Colin_DataAccess;
using WMS_Models.Pro_Models;

namespace WMS_Business.Colin_Business
{
    public class ChuKuBusiness:TypeBusiness
    {

        SqlDbHelper dal = new SqlDbHelper();
        //出库查询
        public List<WMS_Models.CoLinModel.GoStorageModel> Search(WMS_Models.CoLinModel.GoStorageModel m)
        {
            string sql = "select put.goid,put.goname,pro.prname,pro.PrNumber,put.goBatch,spe.spname,put.goNumber,jli.StName, rul.GlName,put.GoSupplierName,put.GoPrepared,sta.SName, put.GoAudit,put.GoAuditTime from GoStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join GLibrary rul on  put.Glid = rul.Glid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where 1=1 ";
            if (!string.IsNullOrEmpty(m.GoName))
            {
                sql += $" and GoName= @GoName ";
            }
            if (!string.IsNullOrEmpty(m.GlName))
            {
                sql += $" and GlName =@GlName ";
            }
            if (!string.IsNullOrEmpty(m.SName))
            {
                sql += $" and SName= @SName ";
            }
            //string sql = "select * from PutStorage where PuName= @PuName and Jlid =@Jlid and Sid= @Sid ";
            return dal.Search<WMS_Models.CoLinModel.GoStorageModel, WMS_Models.CoLinModel.GoStorageModel>(sql, m);
        }
        //出库高级查询
        public List<WMS_Models.CoLinModel.GoStorageModel> Searchs(WMS_Models.CoLinModel.GoStorageModel m)
        {
            string sql = "select put.goid,put.goname,pro.prname,pro.PrNumber,put.goBatch,spe.spname,put.goNumber,jli.StName, rul.GlName,put.GoSupplierName,put.GoPrepared,sta.SName, put.GoAudit,put.GoAuditTime from GoStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join GLibrary rul on  put.Glid = rul.Glid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where 1=1 ";
            if (!string.IsNullOrEmpty(m.GoName))
            {
                sql += $" and PuName= @GoName ";
            }
            if (!string.IsNullOrEmpty(m.Glid))
            {
                sql += $" and Jlid =@Jlid ";
            }
            if (!string.IsNullOrEmpty(m.Sid))
            {
                sql += $" and Sid= @Sid ";
            }
            if (!string.IsNullOrEmpty(m.GoAuditNum))
            {
                sql += $" and PuAuditNum=@GoAuditNum ";
            }
            if (!string.IsNullOrEmpty(m.GoSupplierName))
            {
                sql += $" PuSupplierName=@GoSupplierName ";
            }
            // string sql = "select * from PutStorage where PuName= @PuName and Jlid =@Jlid and Sid= @Sid and PuAuditNum=@PuAuditNum and PuSupplierName=PuSupplierName";
            return dal.Search<WMS_Models.CoLinModel.GoStorageModel, WMS_Models.CoLinModel.GoStorageModel>(sql, m);
        }
        //出库表显示
        public List<WMS_Models.CoLinModel.GoStorageModel> CkShow()
        {
            string sql = "select put.Goid,put.goname,pro.prname,pro.PrNumber,put.goBatch,spe.spname,put.goNumber,jli.StName, rul.GlName,put.GoSupplierName,put.GoPrepared,sta.SName, put.GoAudit,put.GoAuditTime from GoStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join GLibrary rul on  put.Glid = rul.Glid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid";
            return dal.Shows<WMS_Models.CoLinModel.GoStorageModel>(sql);
        }
        //出库表详情显示
        public List<WMS_Models.CoLinModel.GoStorageModel> CkXQShow(string m)
        {
            string sql = " select put.Goid,put.Goid,put.GoName,pro.prname,pro.PrNumber,put.GoAddres,put.GoAuditPeople,put.GoBatch,spe.spname,put.GoNumber,jli.StName,put.GoSupplierName,put.GoAuditNum,rul.GlName,put.GoPrepared,sta.SName,put.GoAuditPeople,put.GoTotalPrice,put.GoPreparedTime,put.GoSupplierName from GoStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join GLibrary rul on put.Glid = rul.Glid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where Goid='" + m + "'";
            return dal.Shows<WMS_Models.CoLinModel.GoStorageModel>(sql);
        }
        /////////////
        ////////////
        ///////////
        //////////
        //添加里的显示
        public List<WMS_Models.CoLinModel.GoStorageModel> AddShow()
        {
            string sql = "select put.puname,put.PuRelevance,put.PuAuditNum,put.PuSupplierName,put.PuAuditPeople,put.PuAuditPhone,put.PuPrepared,put.PuPreparedTime,put.PuAddres,pro.PrName,pro.PrNumber,spe.spname,put.PuBatch,rul.JlName,pro.PrPrice,put.PuNumber,put.PuTotalPrice,jli.StName from PutStorage put join ProductsTB pro on put.Prid = pro.Prid join Rulibrary rul on put.jlid = rul.Jlid join Jlibrary jli on put.Stid = jli.Stid join Specification spe on put.Spid = spe.Spid  ";
            return dal.Shows<WMS_Models.CoLinModel.GoStorageModel>(sql);
        }
        //删除
        public int Deletes(string m)
        {
            string sql = "delete from GoStorage where goid = '" + m + "'";
            return dal.Deletes(sql);
        }
        //添加
        //public int AddS(WMS_Models.Pro_Models.GoStorageModel m)
        //{
        //    string sql = "insert into PutStorage(PuName,PuRelevance,PuAuditNum,PuSupplierName,PuAuditPeople,PuAuditPhone,PuPrepared,PuPreparedTime,PuAddres) values('" + m.PuName + "','" + m.PuRelevance + "','" + m.PuAuditNum + "','" + m.PuSupplierName + "','" + m.PuAuditPeople + "','" + m.PuAuditPhone + "','" + m.PuPrepared + "','" + m.PuPreparedTime + "','" + m.PuAddres + "')";
        //    return dal.Adds(sql);
        //}

        //反填显示
        public WMS_Models.CoLinModel.GoStorageModel UpdateShow(string id)
        {
            string sql = "select * from  GoStorage where Goid ='" + id + "' ";
            return dal.Shows<WMS_Models.CoLinModel.GoStorageModel>(sql).First();
        }
        //修改 
        public int Updates(WMS_Models.CoLinModel.GoStorageModel m)
        {
            string sql = "update PutStorage set Glid ='" + m.Glid + "',GoRelevance='" + m.GoRelevance + "',GoAuditNum = '" + m.GoAuditNum + "',GoSupplierName='" + m.GoSupplierName + "',GoAuditPeople='" + m.GoAuditPeople + "', GoAuditPhone='" + m.GoAuditPhone + "', GoPrepared='" + m.GoPrepared + "', GoAddres='" + m.GoAddres + "' where Goid ='" + m.Goid + "'";
            return dal.Updates(sql);
        }
        //修改状态
        public int UpdateZT(WMS_Models.CoLinModel.GoStorageModel m)
        {
            string sql = "update GoStorage set Sid='" + m.Sid + "' where Goid ='" + m.Goid + "'";
            return dal.Updates(sql);
        }
    }
}
