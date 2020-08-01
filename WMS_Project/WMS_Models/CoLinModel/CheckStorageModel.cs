
using System;
using System.Collections.Generic;
using System.Text;

namespace WMS_Models.CoLinModel
{
    public class CheckStorageModel
    {
		//盘点表
		public Guid Chid { get; set; }
		public string ChName { get; set; }
		public string Prid { get; set; }
		public string ChBatch { get; set; }
		public string Spid { get; set; }
		public int ChNumber { get; set; }
		public string Stid { get; set; }
		public string Clid { get; set; }
		public string ChPrepared { get; set; }
		public string Sid { get; set; }
		public string ChAudit { get; set; }
		public DateTime ChAuditTime { get; set; }
		public string ChRelevance { get; set; }
		public DateTime ChPreparedTime { get; set; }
		public string ChAddres { get; set; }
		public int ChTake { get; set; }
		public int ChProfit { get; set; }
		//产品表 
		public string PrName { get; set; }
		public string PrNumber { get; set; }
		public string PrSpid { get; set; }
		public string PrPtid { get; set; }
		public string Paid { get; set; }
		public string PrShowName { get; set; }
		public string PrUsid { get; set; }
		public string PrPrice { get; set; }
		public string PrWeight { get; set; }

		//库位表
		public string StName { get; set; }
		public string StStorage { get; set; }
		//盘点类型
		public string ClName { get; set; }
		//状态表
		public string SName { get; set; }
		//规格表
		public string SpName { get; set; }

	}
}
