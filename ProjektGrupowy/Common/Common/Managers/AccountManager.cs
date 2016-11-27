using Data.Enums;

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
