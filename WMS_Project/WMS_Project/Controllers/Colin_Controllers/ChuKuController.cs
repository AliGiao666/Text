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
    public class ChuKuController : ControllerBase
    {
        ChuKuBusiness bll = new ChuKuBusiness();
        //出库查询   
        [HttpGet]
        public List<WMS_Models.CoLinModel.GoStorageModel> CKSearch(string name, string jlid, string sid)
        {
            WMS_Models.CoLinModel.GoStorageModel m = new WMS_Models.CoLinModel.GoStorageModel { GoName = name, GlName = jlid, SName = sid };
            return bll.Search(m);
        }
        //出库高级查询  
        [HttpGet]
        public List<WMS_Models.CoLinModel.GoStorageModel> CKSearchs(string name, string jlid, string sid, string punum, string puname)
        {
            WMS_Models.CoLinModel.GoStorageModel m = new WMS_Models.CoLinModel.GoStorageModel { GoName = name, GlName = jlid, SName = sid, GoAuditNum = punum, GoSupplierName = puname };
            return bll.Searchs(m);
        }
        //显示出库表 api/Chuku/RKShow
        [HttpGet]
        public List<WMS_Models.CoLinModel.GoStorageModel> CkShow()
        {
            return bll.CkShow();
        }
        //显示出库类型 api/Chuku/RKTShow
        [HttpGet]
        public List<GLibraryModel> CKTShow()
        {
            return bll.Show<GLibraryModel>();
        }
        ///////////////////
        ///////////////////
        ///////////////////
        ///////////////////
        //显示出库详情表 api/ruku/RKShow
        [HttpGet]
        public List<WMS_Models.CoLinModel.GoStorageModel> CkXQShow(string id)
        {
            return bll.CkXQShow(id);
        }
        //添加里的显示
        [HttpGet]
        public List<WMS_Models.CoLinModel.GoStorageModel> AddShow()
        {
            return bll.AddShow();
        }
        //删除出库表
        [HttpPost]
        public int Deletes(string m)
        {
            return bll.Deletes(m);
        }
        //反射添加表
        [HttpPost]
        public int ChuKuAdd(GoStorageModel m)
        {
            m.GoAuditTime = DateTime.Now;
            m.GoPreparedTime = DateTime.Now;
            return bll.Add(m);
        }
        ////添加
        //[HttpPost]
        //public int RKAdd(GoStorageModel m)
        //{
        //    return bll.AddS(m);
        //}
        //反填显示
        [HttpGet]
        public WMS_Models.CoLinModel.GoStorageModel UpdateShow(string id)
        {
            return bll.UpdateShow(id);
        }
        //修改
        [HttpPost]
        public int CKUpdate(WMS_Models.CoLinModel.GoStorageModel id)
        {
            return bll.Updates(id);
        }
        //修改状态
        [HttpPost]
        public int UpdateZT(WMS_Models.CoLinModel.GoStorageModel id)
        {
            return bll.UpdateZT(id);
        }
        //反射修改
        [HttpPost]
        public int ChuKuUpdate(WMS_Models.CoLinModel.GoStorageModel id)
        {
            id.GoAuditTime = DateTime.Now;
            id.GoPreparedTime = DateTime.Now;
            return bll.Update(id);
        }
        //导出
        public ActionResult DaoContractList()
        {
            //计算总条数
            var list = bll.CkShow().ToList();
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