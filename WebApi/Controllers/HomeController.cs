using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Dto;
using WebApi.Services;

namespace WebApi.Controllers
{
    //路由设置
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        /// <summary>
        /// 两数相减
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> Add(Users param)
        {
            CRUDService crus = new CRUDService();
            Logger.Info(JsonConvert.SerializeObject(param));//此处调用日志记录函数记录日志
            Logger.Error("错误");
            Logger.Warn("警告");
            var ss = crus.QueryS();
            int s =  crus.Add(param);
            return s;
        }
    }
}