using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping.ViewModel
{
    public class JqueryTableDisplay
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public List<string> Languages { get; set; }
        public int Salary { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}