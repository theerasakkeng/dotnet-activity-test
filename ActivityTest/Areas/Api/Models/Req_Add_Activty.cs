using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTest.Areas.Api.Models
{
    public class Req_Add_Activty
    {
        public string? name_th { get; set; }
        public string? name_en { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_through { get; set; }
        public string? desc_th { get; set; }
        public string? desc_en { get; set; }
        public List<IFormFile>? activity_image_url_cover { get; set; }
        public List<IFormFile> activity_image_url_square { get; set; }
        public bool activity_status { get; set; }
        public bool limit_status { get; set; }
        public bool is_delete { get; set; }
        public limit limit { get; set; }

    }
    public class limit
    {
        public int? limit_overall { get; set; }
        public int? limit_perday { get; set; }
        public int? limit_perroom { get; set; }
        public int? limit_permonth { get; set; }
        public int? limit_percustomer { get; set; }
        public int? limit_percustomer_perday { get; set; }
        public int? limit_percustomer_permonth { get; set; }
        public bool? is_delete { get; set; }
    }
}
