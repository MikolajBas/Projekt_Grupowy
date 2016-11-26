using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Managers
{
    public class AccountManager
    {
        public AccountManager()
        {
        }

        public LoginStatus Login(string email, string password)
        {
            return LoginStatus.Success;
        }
    }
}
