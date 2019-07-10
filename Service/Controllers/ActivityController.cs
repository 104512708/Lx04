using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            return Json(DAL.Activity.Instance.GetAll());
        }//复制UsersController.cs对应代码，UserInfo改为Activity

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = DAL.Activity.Instance.GetModel(id);
            if (result != null)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("activityID不存在"));
        }//复制UsersController.cs对应代码，UserInfo改为Activity,string username改为int id，username改为id，错误提示改为activityID不存在

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Model.Activity activity)
        {
            try
            {
                int n = DAL.Activity.Instance.Add(activity);
                return Json(Result.Ok("添加成功",n));
            }
            catch (Exception ex)
            {//复制UsersController.cs对应代码，UserInfo改为Activity，user改为activity，Ok("添加成功")改为Ok("添加成功",n)
                if (ex.Message.ToLower().Contains("foreign key"))
                    return Json(Result.Err("合法用户才能添加记录"));
                else if (ex.Message.ToLower().Contains("null"))//复制UsersController.cs对应代码
                    return Json(Result.Err("活动名称、结束时间、活动图片、活动审核情况、用户名不能为空"));
                else
                    return Json(Result.Err(ex.Message));
            }
        }//复制UsersController.cs对应代码

        // PUT api/<controller>/5
        [HttpPut]
        public ActionResult Put([FromBody]Model.Activity activity)
        {
            try
            {
                var n = DAL.Activity.Instance.Update(activity);
                if (n != 0)
                    return Json(Result.Ok("修改成功"));
                else//复制UsersController.cs对应代码，UserInfo改为Activity，user改为activity
                    return Json(Result.Err("activityID不存在"));
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("null"))//复制UsersController.cs对应代码
                    return Json(Result.Err("活动名称、结束时间、活动图片、活动审核情况不能为空"));
                else
                    return Json(Result.Err(ex.Message));
            }
        }//复制UsersController.cs对应代码

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var n = DAL.Activity.Instance.Delete(id);
                if (n != 0)
                    return Json(Result.Ok("删除成功"));
                else
                    return Json(Result.Err("activityID不存在"));

            }
            catch (Exception ex)
            {
                return Json(Result.Err(ex.Message));
            }
        }//复制UsersController.cs对应代码，UserInfo改为Activity,string username改为int id，username改为id，错误提示改为activityID不存在
        [HttpPut("{id}")]
        public ActionResult upImg(int id,List<IFormFile> files)
        {
            var fileName = $"{AppContext.BaseDirectory}/img/Activity/{id}";            
            try
            {
                var ext = DAL.Upload.Instance.UpImg(files[0], fileName);
                if (ext == null)
                    return Json(Result.Err("请上传图片文件"));
                else
                    return Json(Result.Ok("上传成功", $"img/Activity/{id}{ext}"));
            }
            catch (Exception ex)
            {
                return Json(Result.Err(ex.Message));
            }
        }
    }
}
