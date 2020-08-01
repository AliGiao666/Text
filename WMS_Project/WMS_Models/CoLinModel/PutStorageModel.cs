using System;
using System.Collections.Generic;
using System.Text;

namespace WMS_Models.CoLinModel
{
    public class PutStorageModel
	{
		public string PID { get; set; }
		public Guid Puid { get; set; }
		public string PuName { get; set; }
		public string Prid { get; set; }
		public string PuBatch { get; set; }
		public string Spid { get; set; }
		public int PuNumber { get; set; }
		public string Stid { get; set; }
		public string Jlid { get; set; }
		public string PuSupplierName { get; set; }
		public string PuPrepared { get; set; }
		public string Sid { get; set; }
		public string PuAudit { get; set; }
		public DateTime PuAuditTime { get; set; }
		public string PuAuditNum { get; set; }
		public string PuAuditPeople { get; set; }
		public string PuAuditPhone { get; set; }
		public string PuRelevance { get; set; }
		public DateTime PuPreparedTime { get; set; }
		public string PuAddres { get; set; }
		public int PuTotalPrice { get; set; }

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
		//入库类型
		public string JlName { get; set; }
		//状态表
		public string SName { get; set; }
		//规格表
		public string SpName { get; set; }

	}
}
