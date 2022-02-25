using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping.ViewModel
{
    public class JQueryFormVM
    {

        public string code { get; set; }
        public DateTime dob { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public List<int> languages { get; set; }
        public int salary { get; set; }
        public int state { get; set; }
        public int city { get; set; }
    }
}