namespace Database.Models
{
    public class NotificationConfiguration
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

        public string Message { get; set; }
    }
}
