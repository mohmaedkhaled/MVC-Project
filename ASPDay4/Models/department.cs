using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDay4.Models
{
    public class department
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<user> users { get; set; }
    }
}