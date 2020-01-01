using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Dtos
{
    public class UserForm
    {

        public string user_Name { get; set; }
        public string password { get; set; }
        public string person_Name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public DateTime creation_Date { get; set; }
        public int point { get; set; }
    }

    public class LoginForm
    {
        public string password { get; set; }
        public string email { get; set; }
    }
}
