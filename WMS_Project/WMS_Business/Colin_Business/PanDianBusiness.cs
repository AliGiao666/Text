
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS_DataAccess.Colin_DataAccess;

namespace WMS_Business.Colin_Business
{
    public class PanDianBusiness:TypeBusiness
    {
        SqlDbHelper dal = new SqlDbHelper();
        //盘点查询
        public List<WMS_Models.CoLinModel.CheckStorageModel> Search(WMS_Models.CoLinModel.CheckStorageModel m)
        {
            string sql = "select put.Chid,put.ChName,sta.sname,rul.ClName,  put.ChRelevance,put.chPrepared, put.ChPreparedTime from CheckStorage put join Clibrary rul on  put.Clid = rul.Clid join State sta on put.Sid = sta.Sid where 1=1 ";
            if (!string.IsNullOrEmpty(m.ChName))
            {
                sql += $" and ChName= @ChName ";
            }
            if (!string.IsNullOrEmpty(m.ClName))
            {
                sql += $" and ClName =@ClName ";
            }
            if (!string.IsNullOrEmpty(m.SName))
            {
                sql += $" and SName= @SName ";
            }
            //string sql = "select * from PutStorage where PuName= @PuName and Jlid =@Jlid and Sid= @Sid ";
            return dal.Search<WMS_Models.CoLinModel.CheckStorageModel, WMS_Models.CoLinModel.CheckStorageModel>(sql, m);
        } 
        //盘点表详情显示
        public List<WMS_Models.CoLinModel.CheckStorageModel> PDXQShow(string m)
        {
            string sql = " select put.Chid, put.Chid,put.ChName,pro.prname,pro.PrNumber,put.ChAddres,put.ChBatch,spe.spname,put.CHNumber,jli.StName,put.ChTake,rul.ClName,put.ChRelevance,put.chPrepared,sta.SName,put.ChProfit,put.ChPreparedTime from CheckStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join Clibrary rul on  put.Clid = rul.Clid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where Chid='" + m + "'";
            return dal.Shows<WMS_Models.CoLinModel.CheckStorageModel>(sql);
        }
        //盘点表显示
        public List<WMS_Models.CoLinModel.CheckStorageModel> PDShow()
        {
            string sql = "  select put.Chid,put.ChName,sta.sname,rul.ClName,  put.ChRelevance,put.chPrepared, put.ChPreparedTime from CheckStorage put join Clibrary rul on  put.Clid = rul.Clid join State sta on put.Sid = sta.Sid ";
            return dal.Shows<WMS_Models.CoLinModel.CheckStorageModel>(sql);
        }
        /////////////
        ////////////
        ///////////
        //////////
        //添加里的显示
        public List<WMS_Models.CoLinModel.CheckStorageModel> AddShow()
        {
            string sql = "select put.puname,put.PuRelevance,put.PuAuditNum,put.PuSupplierName,put.PuAuditPeople,put.PuAuditPhone,put.PuPrepared,put.PuPreparedTime,put.PuAddres,pro.PrName,pro.PrNumber,spe.spname,put.PuBatch,rul.JlName,pro.PrPrice,put.PuNumber,put.PuTotalPrice,jli.StName from PutStorage put join ProductsTB pro on put.Prid = pro.Prid join Rulibrary rul on put.jlid = rul.Jlid join Jlibrary jli on put.Stid = jli.Stid join Specification spe on put.Spid = spe.Spid  ";
            return dal.Shows<WMS_Models.CoLinModel.CheckStorageModel>(sql);
        }
        //删除
        public int Deletes(string m)
        {
            string sql = "delete from CheckStorage where Chid = '" + m + "'";
            return dal.Deletes(sql);
        }
        //添加
        //public int AddS(WMS_Models.Pro_Models.CheckStorageModel m)
        //{
        //    string sql = "insert into CheckStorage(PuName,PuRelevance,PuAuditNum,PuSupplierName,PuAuditPeople,PuAuditPhone,PuPrepared,PuPreparedTime,PuAddres) values('" + m.PuName + "','" + m.PuRelevance + "','" + m.PuAuditNum + "','" + m.PuSupplierName + "','" + m.PuAuditPeople + "','" + m.PuAuditPhone + "','" + m.PuPrepared + "','" + m.PuPreparedTime + "','" + m.PuAddres + "')";
        //    return dal.Adds(sql);
        //}

        //反填显示
        public WMS_Models.CoLinModel.CheckStorageModel UpdateShow(string id)
        {
            string sql = "select * from  CheckStorage where Chid ='" + id + "' ";
            return dal.Shows<WMS_Models.CoLinModel.CheckStorageModel>(sql).First();
        }
        //修改 
        public int Updates(WMS_Models.CoLinModel.CheckStorageModel m)
        {
            string sql = "update CheckStorage set Clid='" + m.Clid + "',ChRelevance ='" + m.ChRelevance + "',Sid='" + m.Sid + "',ChPrepared = '" + m.ChPrepared + "',ChTake='" + m.ChTake + "', ChProfit='" + m.ChProfit + "', ChAddres='" + m.ChAddres + "' where Chid ='" + m.Chid + "'";
            return dal.Updates(sql);
        }
        //修改状态
        public int UpdateZT(WMS_Models.CoLinModel.CheckStorageModel m)
        {
            string sql = "update CheckStorage set Sid='" + m.Sid + "' where Chid ='" + m.Chid + "'";
            return dal.Updates(sql);
        }
    }
}
