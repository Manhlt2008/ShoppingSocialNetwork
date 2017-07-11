using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class RecordInfo
    {
        public DateTime CreateDate { set; get; }
        public DateTime ModifyDate { set; get; }
        public int CreateBy { set; get; }
        public int ModifyBy { set; get; }
    }
}