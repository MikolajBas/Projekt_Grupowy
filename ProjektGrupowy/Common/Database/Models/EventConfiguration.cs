namespace Database.Models
{
    public class EventConfiguration
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public int PropertyOperatorId { get; set; }

        public string PropertyValue { get; set; }

        public int OperatorId { get; set; }

        public string ResultValue { get; set; }

        public int FunctionId { get; set; }

        public int Period { get; set; } //number of days

        public int UserId { get; set; }

        public string Template { get; set; }

        public int CategoryId { get; set; }
    }
}
