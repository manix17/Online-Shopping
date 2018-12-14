using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_DAL;

namespace Online_Shopping.ViewModel
{
    public class FormDbDataVM
    {
        public List<tblDemoJQueryForm> DemoJQueryForms { get; set; }
        public List<tblLanguage> languages { get; set; }
        public List<tblLanguageInter> languageInters { get; set; }
        public List<tblState> states { get; set; }
        public List<tblCity> cities { get; set; }
    }
}