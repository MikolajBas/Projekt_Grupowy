using Data.Enums;

namespace Database.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Url { get; set; }

        public AccountType AccountType { get; set; }

        public string Guid { get; set; }
    }
}
