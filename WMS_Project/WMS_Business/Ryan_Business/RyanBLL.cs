using System;
using System.Collections.Generic;
using System.Text;
using WMS_DataAccess.Ryan_DataAccess;
using WMS_Models.Pro_Models;

namespace WMS_Business.Ryan_Business
{
    public class RyanBLL
    {
        RyanDBhelper db = new RyanDBhelper();
        //显示求和库存总数
        public List<StockWarningTBModel> KuCunTotal()
        {
            string sql = "select sum(StockShu) as NumTotal from StockWarningTB  ";
            return db.Show<StockWarningTBModel>(sql);
        }
        //显示本年销售总额
        public List<MarketIncreaseTBModel> YearTotal()
        {
            string sql = "select SUM(Margin) as YearTotal from MarketIncreaseTB where DATEDIFF(YY,MarketTimeId,GETDATE())=0";
            return db.Show<MarketIncreaseTBModel>(sql);
        }
        //显示本周销售总额
        public List<MarketIncreaseTBModel> ZhouTotal()
        {
            string sql = "select SUM(Margin) as ZhouTotal from MarketIncreaseTB where ABS(DATEDIFF(day,getdate(),MarketTimeId))<DATEPART(WEEKDAY,GETDATE())-1";
            return db.Show<MarketIncreaseTBModel>(sql);
        }
        //显示本年采购额
        public List<FinanceDetailTBModel> CaiGouTotal()
        {
            string sql = "select SUM(PaymentMoney) as CaiGouTotal from FinanceDetailTB where DATEDIFF(YY,PaymentTime,GETDATE())=0";
            return db.Show<FinanceDetailTBModel>(sql);
        }
        //显示库存成本
        public List<ProductTBModel> ChengBenTotal()
        {
            string sql = "select sum(MarketPrice * StockNum) as ChengBenTotal from ProductTB p join LedgerDetailTB l on p.ProductId=l.ProductId ";
            return db.Show<ProductTBModel>(sql);
        }
    }
}
