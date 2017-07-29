using Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Common
{
    public static class Helper
    {
        public static UserModel CurrentUser
        {
            get
            {
                if (HttpContext.Current == null) return null;
                var user = HttpContext.Current.User;
                if (user != null && !string.IsNullOrWhiteSpace(user.Identity.Name))
                {
                    var u = JsonConvert.DeserializeObject<UserModel>(user.Identity.Name);
                    return u;
                }
                return null;
            }
        }
    }
}