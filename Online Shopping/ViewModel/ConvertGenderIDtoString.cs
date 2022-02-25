using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping.ViewModel
{
    public static class ConvertGenderIDtoString
    {
        public static string Convert(int id)
        {
            if(id == 1)
            {
                return "Male";
            }
            else if(id == 2)
            {
                return "Female";
            }
            else if(id == 3)
            {
                return "Transgender";
            }
            else
            {
                return "Not Stated";
            }
        }
    }
}