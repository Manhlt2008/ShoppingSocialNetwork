using System;
using FluentData;
using System.Configuration;

namespace Admin.DAL
{
    public class MainDBContext
    {
        public static IDbContext MainDB()
        {
            return new FluentData.DbContext().ConnectionString(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, new SqlServerProvider());
        }
    }
}