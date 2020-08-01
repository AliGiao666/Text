using System;
using System.Collections.Generic;
using System.Text;

namespace WMS_Models.CoLinModel
{
    public class GoStorageModel
    {
		//出库表
		public Guid Goid { get; set; }
		public string GoName { get; set; }
		public string Prid { get; set; }
		public string GoBatch { get; set; }
		public string Spid { get; set; }
		public int GoNumber { get; set; }
		public string Stid { get; set; }
		public string Glid { get; set; }
		public string GoSupplierName { get; set; }
		public string GoPrepared { get; set; }
		public string Sid { get; set; }
		public string GoAudit { get; set; }
		public DateTime GoAuditTime { get; set; }
		public string GoAuditNum { get; set; }
		public string GoAuditPeople { get; set; }
		public string GoAuditPhone { get; set; }
		public string GoRelevance { get; set; }
		public DateTime GoPreparedTime { get; set; }
		public string GoAddres { get; set; }
		public int GoTotalPrice { get; set; }
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
		//出库类型
		public string GlName { get; set; }
		//状态表
		public string SName { get; set; }
		//规格表
		public string SpName { get; set; }
	}
}
