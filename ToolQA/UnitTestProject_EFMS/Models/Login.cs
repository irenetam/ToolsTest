using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.Commons;

namespace UnitTestProject_EFMS.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Login() { }
        public void InitData()
        {
            this.Email = CommonMethods.GenerateRandomEmail();
            this.Password = CommonMethods.GenerateRandomString();
        }
    }
}
