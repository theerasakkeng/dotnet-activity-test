using System;
using System.Collections.Generic;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class BCRM_MQDC_Project
    {
        public int Project_id { get; set; }
        public string Project_name_th { get; set; }
        public string Project_name_en { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
    }
}
