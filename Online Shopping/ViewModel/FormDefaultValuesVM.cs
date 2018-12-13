using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_DAL;

namespace Online_Shopping.ViewModel
{
    public class FormDefaultValuesVM
    {
        public List<tblLanguage> LanguagesKnown { get; set; }
        public List<tblState> States { get; set; }
        public List<tblCity> Cities { get; set; }
    }
}