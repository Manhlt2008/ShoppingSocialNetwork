using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.DAL
{
    public class UserListBL
    {
        public UserList GetUserByUserPass(string userName,string pass)
        {
            UserList u = new UserList();
            using (var context = MainDBContext.MainDB())
            {
                var result = context.StoredProcedure("UserList_GetByUserPass")
                    .Parameter("Username", userName)
                    .Parameter("Password", pass)
                    .QuerySingle<UserList>();
                u = result;
            }
            return u;
        }
        public  UserModel GetPermission_ByUserName(string userName)
        {
            UserModel model = new UserModel();
            using (var context = MainDBContext.MainDB())
            {
                var result = context.StoredProcedure("GetPermission_ByUserName")
                    .Parameter("UserName", userName)
                    .QuerySingle<UserModel>();
                model = result;
            }
            return model;
        }
    }
}