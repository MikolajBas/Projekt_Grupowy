using Data.Enums;
using Microsoft.AspNet.Identity;

namespace Database.Models
{
    public class User : BaseModel<User>, IUser<int>
    {
        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Url { get; set; }

        public virtual AccountType AccountType { get; set; }

        public virtual string Guid { get; set; }
    }
}
