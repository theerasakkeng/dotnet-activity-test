using ActivityTest.Areas.Api.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTest.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadCSVController : ControllerBase
    {
        private object records;

        [HttpPost]
        [Route("UploadCSV")]
        public async Task<IActionResult> UploadCSV([FromForm] Req_CSV_FileClass req)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            try
            {
               using (var reader = new StreamReader(req.file.OpenReadStream()))
                {
                    using(var csv = new CsvReader(reader, config))
                    {
                        var records = csv.GetRecords<CSV_Field>().ToList();
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception($"Error parsing the Csv File. Error: {e.Message}");
            }
            return Ok(records);
        }
    }
}
