using System;
using System.Collections.Generic;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class BCRM_MQDC_Activity_Period
    {
        public int Activity_period_id { get; set; }
        public int Activity_info_id { get; set; }
        public int Project_id { get; set; }
        public DateTime DateTime_Activity { get; set; }
        public bool Period_Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
    }
}
