namespace Database.Models
{
    public class DataCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }
    }
}
