using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTest.Areas.Api.Models
{
    public class Req_Add_Activty
    {
        public string name_th { get; set; }
        public string name_en { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_through { get; set; }
        public string desc_th { get; set; }
        public string desc_en { get; set; }
        public string activity_image_url_cover { get; set; }
        public string activity_image_url_square { get; set; }
        public bool activity_status { get; set; }
        public bool limit_status { get; set; }
        public bool is_delete { get; set; }
        public Req_Limit Req_Limit { get; set; }

    }
    public class Req_Limit
    {
        public int limit_overall { get; set; }

    }
}
