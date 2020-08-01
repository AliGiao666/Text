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
    public class PanDianController : ControllerBase
    {
        PanDianBusiness bll = new PanDianBusiness();
        //盘点查询  api/pandian/PDSearch?name=  
        [HttpGet]
        public List<WMS_Models.CoLinModel.CheckStorageModel> PDSearch(string name, string jlid, string sid)
        {
            WMS_Models.CoLinModel.CheckStorageModel m = new WMS_Models.CoLinModel.CheckStorageModel { ChName = name, ClName = jlid, SName = sid };
            return bll.Search(m);
        } 
        //显示盘点表 api/PANDIAN/RKShow
        [HttpGet]
        public List<WMS_Models.CoLinModel.CheckStorageModel> PDShow()
        {
            return bll.PDShow();
        }
        //显示盘点详情表 api/PANDIAN/RKShow
        [HttpGet]
        public List<WMS_Models.CoLinModel.CheckStorageModel> PDXQShow(string id)
        {
            return bll.PDXQShow(id);
        }
        //显示盘点类型 api/PANDAIN/PDTShow
        [HttpGet]
        public List<ClibraryModel> PDTShow()
        {
            return bll.Show<ClibraryModel>();
        }
        ///////////////////
        ///////////////////
        ///////////////////
        ///////////////////
        
        //添加里的显示
        [HttpGet]
        public List<WMS_Models.CoLinModel.CheckStorageModel> AddShow()
        {
            return bll.AddShow();
        }
        //删除入库表
        [HttpPost]
        public int Deletes(string m)
        {
            return bll.Deletes(m);
        }
        //反射添加入坤表
        [HttpPost]
        public int PanDianAdd(CheckStorageModel m)
        {
            m.ChAuditTime = DateTime.Now;
            m.ChPreparedTime = DateTime.Now;
            return bll.Add(m);
        }
        ////添加
        //[HttpPost]
        //public int RKAdd(CheckStorageModel m)
        //{
        //    return bll.AddS(m);
        //}
        //反填显示
        [HttpGet]
        public WMS_Models.CoLinModel.CheckStorageModel UpdateShow(string id)
        {
            return bll.UpdateShow(id);
        }
        ////修改
        [HttpPost]
        public int PDUpdate(WMS_Models.CoLinModel.CheckStorageModel id)
        {
            return bll.Updates(id);
        }
        //修改状态
        [HttpPost]
        public int UpdateZT(WMS_Models.CoLinModel.CheckStorageModel id)
        {
            return bll.UpdateZT(id);
        }
        //导出
        public ActionResult DaoContractList()
        {
            //计算总条数
            var list = bll.PDShow().ToList();
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