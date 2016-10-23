namespace Database.Models
{
    public class DataCategory
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual int UserId { get; set; }
    }
}
