using Data.Enums;

namespace Database.Models
{
    public class User : BaseModel<User>
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Url { get; set; }

        public virtual AccountType AccountType { get; set; }

        public virtual string Guid { get; set; }
    }
}
