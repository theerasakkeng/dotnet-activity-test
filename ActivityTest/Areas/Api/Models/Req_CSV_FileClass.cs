using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTest.Areas.Api.Models
{
    public class Req_CSV_FileClass
    {
        public IFormFile file { get; set; }
    }

    public class CSV_Field
    {
        public string? receipt { get; set; }
        public string? name { get; set; }
        public string? last_name { get; set; }
        public string? mobile { get; set; }
        public string? store { get; set; }
        public DateTime? pusch_date { get; set; }
        public DateTime? upload_date { get; set; }
        public int? boadrd { get; set; }
        public int? wood { get; set; }
        public int point1 { get; set; }
    }
}
