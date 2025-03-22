using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDay4.Models
{
    public class catalog
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public virtual List<news> News { get; set; }
    }
}