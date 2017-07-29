using Admin.Common;
using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    
    public class BaseController : Controller
    {
        public UserModel CurrentUser
        {
            get
            {
                return Helper.CurrentUser;
            }
        }
    }
}