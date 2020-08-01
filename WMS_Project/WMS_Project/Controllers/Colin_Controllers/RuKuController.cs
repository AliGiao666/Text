using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WMS_Business.Colin_Business;
using WMS_Models.Pro_Models;

namespace WMS_Project.Controllers.Colin_Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RuKuController : ControllerBase
    {
        RuKuBusiness bll = new RuKuBusiness();

        //入库查询  api/ruku/RKSearch?name=RKD10003  
        [HttpGet]
        public List<WMS_Models.CoLinModel.PutStorageModel> RkSearch(string name, string jlid, string sid)
        {
            WMS_Models.CoLinModel.PutStorageModel m = new WMS_Models.CoLinModel.PutStorageModel { PuName = name, JlName = jlid, SName = sid };
            return bll.Search(m);
        }
        //入库高级查询  api/ruku/searchs?name=rkd10003&jlid=8e7580bf56dc&sid=88707a9f5b37&punum=GYS202001&puname=华为科技
        [HttpGet]
        public List<WMS_Models.CoLinModel.PutStorageModel> RkSearchs(string name, string jlid, string sid, string punum, string puname)
        {
            WMS_Models.CoLinModel.PutStorageModel m = new WMS_Models.CoLinModel.PutStorageModel { PuName = name, JlName = jlid, SName = sid, PuAuditNum = punum, PuSupplierName = puname };
            return bll.Searchs(m);
        }  
        //显示入库表 api/ruku/RKShow
        [HttpGet]
        public List<WMS_Models.CoLinModel.PutStorageModel> RkShow()
        {
            return bll.RkShow();
        }
        //显示入库详情表 api/ruku/RKShow
        [HttpGet]
        public List<WMS_Models.CoLinModel.PutStorageModel> RkXQShow(string id)
        {
            return bll.RkXQShow(id);
        }
        //添加里的显示
        [HttpGet]
        public List<WMS_Models.CoLinModel.PutStorageModel> AddShow()
        {
            return bll.AddShow();
        }
        //显示入库类型 api/ruku/RKTShow
        [HttpGet]
        public List<RulibraryModel> RKTShow()
        {
            return bll.Show<RulibraryModel>();
        }
        //删除入库表 api/ruku/Delete
        [HttpPost]
        public int Delete(WMS_Models.CoLinModel.PutStorageModel m)
        {
            return bll.Delete<WMS_Models.CoLinModel.PutStorageModel>(m);
        }
        //删除入库表
        [HttpPost]
        public int Deletes(string m)
        {
            return bll.Deletes(m);
        }
        //反射添加入坤表
        [HttpPost]
        public int RuKuAdd(PutStorageModel m) 
        {
            m.PuAuditTime = DateTime.Now;
            m.PuPreparedTime = DateTime.Now;
            return bll.Add(m);
        }
        //添加
        [HttpPost]
        public int RKAdd(PutStorageModel m)
        {
            return bll.AddS(m);
        }
        //反填显示
        [HttpGet]
        public WMS_Models.CoLinModel.PutStorageModel UpdateShow(string id)
        {
            return bll.UpdateShow(id);
        }
        //修改
        [HttpPost]
        public int RKUpdate(WMS_Models.CoLinModel.PutStorageModel id)
        {
            return bll.Updates(id);
        }
        //修改状态
        [HttpPost]
        public int UpdateZT(WMS_Models.CoLinModel.PutStorageModel id)
        {
            return bll.UpdateZT(id);
        }
        //反射修改
        [HttpPost]
        public int RKFSUpdate(WMS_Models.CoLinModel.PutStorageModel m)
        {
            return bll.Update(m);
        }
        //导出
        public ActionResult DaoContractList()
        {
            //计算总条数
            var list = bll.RkShow().ToList();
            //转为json格式
            var json = JsonConvert.SerializeObject(list);
            //转为dataTable
            DataTable dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(json);
            var msg = string.Empty;//返回消息
            string[] sColumnName = { "合同编号", "合同名称", "合同类型", "供应商", "采购物品", "需求数量", "我方签约人", "合同金额", "开始时间", "结束时间", "合同状态" };

            //调用帮助类里的导出方法
            byte[] by = WMS_Models.CoLinModel.DaoChu.ExportExcel(dt, "", "导出信息", sColumnName, ref msg);
            return File(by, "application/ms-excel", "test.xlsx");
        }
       
    }
}