using System;
using System.Collections.Generic;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class DB_Customer
    {
        public string customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_no { get; set; }
        public DateTime? birth_date { get; set; }
        public string gender { get; set; }
        public string address_info { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string sub_district { get; set; }
        public string post_code { get; set; }
    }
}
