using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class UserList : RecordInfo
    {
        public string Username { get; set; }
        public string GroupID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public int Status { get; set; }   
    }
    public class UserModel
    {
        public string Username { get; set; }
        public string GroupID { get; set; }  
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string GroupName { get; set; }
        public string RoleName { get; set; }  
    }
}