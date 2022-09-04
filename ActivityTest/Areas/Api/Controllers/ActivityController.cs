using ActivityTest.Areas.Api.Models;
using ActivityTest.ModelsDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTest.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly DB_Context db_context;
        public object Data = null;
        public ActivityController(DB_Context context)
        {
            this.db_context = context;
        }
        [HttpPost]
        [Route("CreateActivity")]
        public async Task<IActionResult> CreateActivity([FromBody] Req_Add_Project req)
        {
            DateTime txTimeStamp = DateTime.Now;
            try
            {
                BCRM_MQDC_Project project_data = new BCRM_MQDC_Project();
                {
                    project_data.Project_name_en = req.project_name_en;
                    project_data.CreateTime = txTimeStamp;
                    project_data.UpdatedTime = txTimeStamp;
                    project_data.IsDelete = false;
                }
                db_context.BCRM_MQDC_Projects.Add(project_data);
                db_context.SaveChanges();
                int project_id = project_data.Project_id;
                Data = new
                {
                    data = db_context.BCRM_MQDC_Projects.ToList(),
                    status = "success",
                    id = project_id
                };
            }
            catch
            {
                throw;
            }
            return Ok(Data);
        }
    }
}
