using ActivityTest.Areas.Api.Models;
using ActivityTest.ModelsDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTest.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly DB_Context db_context;
        public ActivityController(DB_Context context)
        {
            this.db_context = context;
        }
        //api/Activity/GetActivity
        [HttpGet]
        [Route("GetActivity")]
        public IActionResult GetActivity(int start, int limit)
        {
            object Data = null;
            DateTime txTimeStamp = DateTime.Now;
            try
            {
                List<int> activity_id = db_context.BCRM_MQDC_Activities.Select(o => o.Activity_info_id).ToList();
                //List<dynamic> limit_payload = new List<dynamic>();
                List<dynamic> activity_payload = new List<dynamic>();
                var limit_data = new object();
                var activity_data = new object();
                foreach (var limitId in activity_id)
                {
                    BCRM_MQDC_Limitation limit_data_select = db_context.BCRM_MQDC_Limitations.Where(o => o.Activity_info_id == limitId).FirstOrDefault();
                    if (limit_data_select == null)
                    {
                        limit_data = null;
                    }
                    else
                    {
                        limit_data = new
                        {
                            activity_id = limit_data_select.Activity_info_id,
                            limit_id = limit_data_select.Limit_id,
                            over_all = limit_data_select.Limit_Overall,
                        };
                    }
                    //limit_payload.Add(limit_data);
                    BCRM_MQDC_Activity activity_data_select = db_context.BCRM_MQDC_Activities.Where(o => o.Activity_Status == true && o.Activity_info_id == limitId).FirstOrDefault();
                    activity_data = new
                    {
                        activity_id = activity_data_select.Activity_info_id,
                        activity_status = activity_data_select.Activity_Status,
                        name_en = activity_data_select.Name_en,
                        name_th = activity_data_select.Name_th,
                        create_date = activity_data_select.CreateTime.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                        create_time = activity_data_select.CreateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
                        limit_data
                    };
                    activity_payload.Add(activity_data);
                }
                int total = activity_payload.Count();
                int pageSize = 5;
                int page = 2;
                var skip = pageSize * (page - 1);
                var data_pay = activity_payload.Select(o => o).Skip(skip).Take(pageSize).ToArray();
                Data = new
                {
                    data = new
                    {
                        activity_list = data_pay,
                        total_all = total
                    },
                    status = "success",
                };

            }
            catch
            {
                throw;
            }
            return Ok(Data);
        }
        //api/Activity/CreateProject
        [HttpPost]
        [Route("CreateProject")]
        public async Task<IActionResult> CreateProject([FromBody] Req_Add_Project req)
        {
            object Data = null;
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
                };
            }
            catch
            {
                throw;
            }
            return Ok(Data);
        }
        //api/Activity/CreateActivity
        [HttpPost]
        [Route("CreateActivity")]
        public async Task<IActionResult> CreateActivity([FromBody] Req_Add_Activty req)
        {
            DateTime txTimeStamp = DateTime.Now;
            bool ckeck_limit = req.limit_status;
            object Data = null;
            try
            {
                BCRM_MQDC_Activity activity_data = new BCRM_MQDC_Activity();
                {
                    activity_data.Name_en = req.name_en;
                    activity_data.Name_th = req.name_th;
                    activity_data.Activity_Status = req.activity_status;
                    activity_data.Limit_Status = req.limit_status;
                    activity_data.IsDelete = req.is_delete;
                    activity_data.UpdatedTime = txTimeStamp;
                    activity_data.CreateTime = txTimeStamp;
                    activity_data.Valid_From = txTimeStamp;
                    activity_data.Valid_Through = txTimeStamp;
                }
                db_context.BCRM_MQDC_Activities.Add(activity_data);
                db_context.SaveChanges();
                int activity_id = activity_data.Activity_info_id;
                if (ckeck_limit)
                {
                    BCRM_MQDC_Limitation limit_data = new BCRM_MQDC_Limitation();
                    {
                        limit_data.Activity_info_id = activity_id;
                        limit_data.Limit_Overall = req.limit.limit_overall;
                        limit_data.CreateTime = txTimeStamp;
                        limit_data.UpdatedTime = txTimeStamp;
                        limit_data.IsDelete = false;
                    }
                    db_context.BCRM_MQDC_Limitations.Add(limit_data);
                    db_context.SaveChanges();
                }
                Data = new
                {
                    data = new
                    {
                        activity_list = activity_data,
                    }
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
