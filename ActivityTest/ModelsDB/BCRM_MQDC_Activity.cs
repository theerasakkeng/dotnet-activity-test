﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class BCRM_MQDC_Activity
    {
        public int Activity_info_id { get; set; }
        public string Name_th { get; set; }
        public string Name_en { get; set; }
        public DateTime Valid_From { get; set; }
        public DateTime Valid_Through { get; set; }
        public string Desc_th { get; set; }
        public string Desc_en { get; set; }
        public string Activity_Image_Url_Cover { get; set; }
        public string Activity_Image_Url_Square { get; set; }
        public bool Activity_Status { get; set; }
        public bool Limit_Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
    }
}
