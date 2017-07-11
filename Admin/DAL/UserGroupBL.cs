using Admin.Models;
using System.Collections.Generic;

namespace Admin.DAL
{
    public class UserGroupBL
    {
        public void Insert(UserGroup ug)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("UserGroup_Insert")
                    .Parameter("GroupID", ug.GroupID)
                    .Parameter("GroupName", ug.GroupName)
                    .Parameter("Note", ug.Note)      
                    .Execute();
            }
        }

        public void Update(UserGroup ug)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("UserGroup_Update")
                    .Parameter("GroupID", ug.GroupID)
                    .Parameter("GroupName", ug.GroupName)
                    .Parameter("Note", ug.Note)
                    .Execute();
            }
        }

        public void Delete(string groupID)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("UserGroup_Delete").Parameter("GroupID", groupID).Execute();
            }
        }
        public List<UserGroup> GetListUserGroup()
        {
            using (var context = MainDBContext.MainDB())
            {
                return context.StoredProcedure("UserGroup_GetAll").QueryMany<UserGroup>();
            }
        }
        public UserGroup GetUserGroupById(string groupID)
        {
            UserGroup ug = new UserGroup();
            using (var context = MainDBContext.MainDB())
            {
                var result = context.StoredProcedure("UserGroup_GetByGroupID")
                    .Parameter("GroupID", groupID)
                    .QuerySingle<UserGroup>();
                ug = result;
            }
            return ug;
        }
    }
}