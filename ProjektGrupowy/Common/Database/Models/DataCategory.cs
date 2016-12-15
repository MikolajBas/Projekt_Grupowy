namespace Database.Models
{
    public class DataCategory //defined by client - information for validation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; } //not important

        public int UserId { get; set; }
    }
}
