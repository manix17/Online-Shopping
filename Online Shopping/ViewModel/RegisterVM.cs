using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_DAL;
using System.Web.Mvc;
using Online_Shopping.Models;

namespace Online_Shopping.ViewModel
{
    public class RegisterVM
    {
        public tblUser User { get; set; }
        public SelectList Profile { get; set; }
        public RegisterModel UserCnfPwd { get; set; }
    }
}