using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_Business.Ryan_Business;
using WMS_Models.Pro_Models;

namespace WMS_Project.Controllers.Ryan_Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //api/ryan/ChengBenTotal
    public class RyanController : ControllerBase
    {
        RyanBLL bll = new RyanBLL();
        //显示求和库存总量
        public List<StockWarningTBModel> KuCunTotal()
        {
            return bll.KuCunTotal();
        }

        //显示本年销售总额
        public List<MarketIncreaseTBModel> YearTotal()
        {
            return bll.YearTotal();
        }

        //显示本周销售总额
        public List<MarketIncreaseTBModel> ZhouTotal()
        {
            return bll.ZhouTotal();
        }
        //显示本年采购额
        public List<FinanceDetailTBModel> CaiGouTotal()
        {
            return bll.CaiGouTotal();
        }
        //显示库存成本
        public List<ProductTBModel> ChengBenTotal()
        {
            return bll.ChengBenTotal();
        }


    }
}
