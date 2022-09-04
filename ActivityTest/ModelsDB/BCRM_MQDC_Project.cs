using System;
using System.Collections.Generic;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class BCRM_MQDC_Project
    {
        public BCRM_MQDC_Project()
        {
            BCRM_MQDC_Activity_Periods = new HashSet<BCRM_MQDC_Activity_Period>();
        }

        public int Project_id { get; set; }
        public string Project_name_th { get; set; }
        public string Project_name_en { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<BCRM_MQDC_Activity_Period> BCRM_MQDC_Activity_Periods { get; set; }
    }
}
