namespace Database.Models
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual int AccountType { get; set; }
    }
}
