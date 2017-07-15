using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class RecordInfo
    {
        public DateTime CreatedAt { set; get; }
        public DateTime ModifiedAt { set; get; }
        public int CreatedBy { set; get; }
        public int ModifiedBy { set; get; }
    }
}