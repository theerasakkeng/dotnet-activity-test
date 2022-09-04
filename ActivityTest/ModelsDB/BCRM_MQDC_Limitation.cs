using System;
using System.Collections.Generic;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class BCRM_MQDC_Limitation
    {
        public int Limit_id { get; set; }
        public int Activity_info_id { get; set; }
        public int? Limit_Overall { get; set; }
        public int? Limit_PerDay { get; set; }
        public int? Limit_PerRoom { get; set; }
        public int? Limit_PerMonth { get; set; }
        public int? Limit_PerCustomer { get; set; }
        public int? Limit_PerCustomer_PerDay { get; set; }
        public int? Limit_PerCustomer_PerMonth { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }

        public virtual BCRM_MQDC_Activity Activity_info { get; set; }
    }
}
