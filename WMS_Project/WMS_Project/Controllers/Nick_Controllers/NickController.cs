using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_Business.Nick_Business;
using WMS_Models.Pro_Models;

namespace WMS_Project.Controllers.Nick_Controllers
{
    [Route("api")]
    [ApiController]
    public class NickController : ControllerBase
    {
        UserBusiness bll = new UserBusiness();
       

        [HttpGet]
        [Route("showuser")]
        public List<UserInfoModel> ShowUser()
        {
            return bll.Show<UserInfoModel>();
        }

        [HttpGet]
        [Route("search")]
        public List<UserInfoModel> Search(string name, string gonghao, int did, int jid)
        {

            UserInfoModel user = new UserInfoModel { UserName = name, UserNumber = gonghao, Department = did, role = jid };
            return bll.Search(user);
        }

        [HttpGet]
        [Route("showdepart")]
        public List<DepartmentTBModel> Department()
        {
            return bll.Show<DepartmentTBModel>();
        }

        [HttpGet]
        [Route("showrole")]
        public List<RoleTBModel> Role()
        {
            return bll.Show<RoleTBModel>();
        }

        [HttpPost]
        [Route("deluser")]
        public int DelUser(Guid id)
        {
            UserInfoModel user = new UserInfoModel { Id = id };
            return bll.Delete(user);

        }
    }
}
