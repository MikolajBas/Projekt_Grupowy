namespace Database.Models
{
    public class EventConfiguration
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public string PropertyOperator { get; set; }

        public string PropertyValue { get; set; }

        public string Operator { get; set; }

        public int ResultValue { get; set; }

        public string Function { get; set; }

        public int Period { get; set; } //number of days

        public int UserId { get; set; }

        public string Template { get; set; }

        public int CategoryId { get; set; }
    }
}
