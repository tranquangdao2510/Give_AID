using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Aid.Common
{
    [Serializable]
    public class CustomerLogin
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}