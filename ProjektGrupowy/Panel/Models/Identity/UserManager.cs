using Database;
using Database.Models;
using Microsoft.AspNet.Identity;

namespace Panel.Models.Identity
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
            var session = Connector.OpenSession();
            Store = new Panel.Models.Identity.IdentityStore(session);
            UserValidator = new UserValidator<User, int>(this);
            PasswordValidator = new PasswordValidator();
        }
    }
}
