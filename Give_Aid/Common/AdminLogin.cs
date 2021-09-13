using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Common
{
    [Serializable]
    public class AdminLogin
    {
        public long AdminId { get; set; }
        public string AdminName { get; set; }
        public string GroupAdminId { get; set; }
    }
}