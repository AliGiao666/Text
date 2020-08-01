using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS_DataAccess.Colin_DataAccess;
using WMS_Models.CoLinModel;
using WMS_Models.Pro_Models;

namespace WMS_Business.Colin_Business
{
    public class RuKuBusiness:TypeBusiness
    {
        SqlDbHelper dal = new SqlDbHelper();
        //入库查询
        public List<WMS_Models.CoLinModel.PutStorageModel> Search(WMS_Models.CoLinModel.PutStorageModel m)
        {
            string sql = "select put.puid,put.puname,pro.prname,pro.PrNumber,put.PuBatch,spe.spname,put.puNumber,jli.StName,rul.jlname,put.PuSupplierName,put.PuPrepared,sta.SName,put.PuAudit,put.PuAuditTime from PutStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join Rulibrary rul on  put.jlid = rul.jlid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where 1=1 ";
            if (!string.IsNullOrEmpty(m.PuName))
            {
                sql += $" and PuName= @PuName ";
            }
            if (!string.IsNullOrEmpty(m.JlName))
            {
                sql += $" and JlName =@JlName ";
            }
            if (!string.IsNullOrEmpty(m.SName))
            {
                sql += $" and SName= @SName ";
            }
            //string sql = "select * from PutStorage where PuName= @PuName and Jlid =@Jlid and Sid= @Sid ";
            return dal.Search<WMS_Models.CoLinModel.PutStorageModel, WMS_Models.CoLinModel.PutStorageModel>(sql, m);
        }
        //入库高级查询
        public List<WMS_Models.CoLinModel.PutStorageModel> Searchs(WMS_Models.CoLinModel.PutStorageModel m)
        {
            string sql = "select put.puid,put.puname,pro.prname,pro.PrNumber,put.PuBatch,spe.spname,put.puNumber,jli.StName,rul.jlname,put.PuSupplierName,put.PuPrepared,sta.SName,put.PuAudit,put.PuAuditTime from PutStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join Rulibrary rul on  put.jlid = rul.jlid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where 1=1 ";
            if (!string.IsNullOrEmpty(m.PuName))
            {
                sql += $" and PuName= @PuName ";
            }
            if (!string.IsNullOrEmpty(m.JlName))
            {
                sql += $" and JlName =@JlName ";
            }
            if (!string.IsNullOrEmpty(m.SName))
            {
                sql += $" and SName= @SName ";
            }
            if (!string.IsNullOrEmpty(m.PuAuditNum))
            {
                sql += $" and PuAuditNum=@PuAuditNum ";
            }
            if (!string.IsNullOrEmpty(m.PuSupplierName))
            {
                sql += $" PuSupplierName=@PuSupplierName ";
            }
           // string sql = "select * from PutStorage where PuName= @PuName and Jlid =@Jlid and Sid= @Sid and PuAuditNum=@PuAuditNum and PuSupplierName=PuSupplierName";
            return dal.Search<WMS_Models.CoLinModel.PutStorageModel, WMS_Models.CoLinModel.PutStorageModel>(sql, m);
        }
        
        //入库表显示 
        public List<WMS_Models.CoLinModel.PutStorageModel> RkShow()
        {
            string sql = "select put.puid,put.puname,pro.prname,pro.PrNumber,put.PuBatch,spe.spname,put.puNumber,jli.StName,rul.jlname,put.PuSupplierName,put.PuPrepared,sta.SName,put.PuAudit,put.PuAuditTime from PutStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join Rulibrary rul on  put.jlid = rul.jlid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid";
            return dal.Shows<WMS_Models.CoLinModel.PutStorageModel>(sql);
        }
        //入库详情显示
        public List<WMS_Models.CoLinModel.PutStorageModel> RkXQShow(string m)
        {
            string sql = "select put.Puid,put.PuName,put.PuSupplierName,put.PuAuditPeople,PuAuditPhone,put.PuPrepared,put.PuPreparedTime,put.PuBatch,put.PuNumber,put.PuTotalPrice,rul.JlName,sta.SName,pro.PrNumber,pro.PrName,spe.SpName,pro.PrPrice,jli.StName from PutStorage put join ProductsTB pro on put.Prid = pro.prid join Specification spe on put.spid = spe.spid join Rulibrary rul on put.jlid = rul.jlid join State sta on put.Sid = sta.Sid join jlibrary jli on put.Stid = jli.Stid where puid='" + m+"'";
            return dal.Shows<WMS_Models.CoLinModel.PutStorageModel>(sql);
        }
        //添加里的显示
        public List<WMS_Models.CoLinModel.PutStorageModel> AddShow()
        {
            string sql = "select put.puname,put.PuRelevance,put.PuAuditNum,put.PuSupplierName,put.PuAuditPeople,put.PuAuditPhone,put.PuPrepared,put.PuPreparedTime,put.PuAddres,pro.PrName,pro.PrNumber,spe.spname,put.PuBatch,rul.JlName,pro.PrPrice,put.PuNumber,put.PuTotalPrice,jli.StName from PutStorage put join ProductsTB pro on put.Prid = pro.Prid join Rulibrary rul on put.jlid = rul.Jlid join Jlibrary jli on put.Stid = jli.Stid join Specification spe on put.Spid = spe.Spid  ";
            return dal.Shows<WMS_Models.CoLinModel.PutStorageModel>(sql);
        }
        //删除
        public int Deletes(string m)
        {
            string sql = "delete from PutStorage where Puid = '"+m+"'";
            return dal.Deletes(sql);
        }
        //添加
        public int AddS(WMS_Models.Pro_Models.PutStorageModel m)
        {
            string sql = "insert into PutStorage(PuName,PuRelevance,PuAuditNum,PuSupplierName,PuAuditPeople,PuAuditPhone,PuPrepared,PuPreparedTime,PuAddres) values('" + m.PuName + "','"+m.PuRelevance + "','"+m.PuAuditNum + "','"+m.PuSupplierName + "','"+m.PuAuditPeople + "','"+m.PuAuditPhone + "','"+m.PuPrepared + "','" + m.PuPreparedTime + "','" + m.PuAddres + "')";
            return dal.Adds(sql);             
        }

        //反填显示
        public WMS_Models.CoLinModel.PutStorageModel UpdateShow(string id)
        {
            string sql = "select * from  PutStorage where puid ='"+id+"' ";
            return dal.Shows<WMS_Models.CoLinModel.PutStorageModel>(sql).First();
        }
        //修改 
        public int Updates(WMS_Models.CoLinModel.PutStorageModel m)
        {
            string sql = "update PutStorage set Jlid='" + m.Jlid + "',PuRelevance ='" + m.PuRelevance + "',PuAuditPhone='" + m.PuAuditPhone + "',PuName = '" + m.PuName + "',PuBatch='" + m.PuBatch + "',PuSupplierName='" + m.PuSupplierName + "', PuPrepared='" + m.PuPrepared + "', PuAudit='" + m.PuAudit + "', PuAuditNum='" + m.PuAuditNum + "', PuAuditPeople='" + m.PuAuditPeople + "',PuAddres='"+m.PuAddres + "',PuPreparedTime='" + m.PuPreparedTime + "' where puid ='" + m.Puid + "'";
            return dal.Updates(sql);
        }
        //修改状态
        public int UpdateZT(WMS_Models.CoLinModel.PutStorageModel m)
        {
            string sql = "update PutStorage set Sid='" + m.Sid + "' where puid ='" + m.Puid + "'";
            return dal.Updates(sql);
        }
    }                                            
}                                                
                                                
                                                 
                                                 