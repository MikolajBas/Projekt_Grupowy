namespace Database.Models
{
    public class NotificationConfiguration : BaseModel<NotificationConfiguration>
    {
        public virtual int Id { get; set; }

        public virtual int PropertyId { get; set; }

        public virtual int PropertyOperatorId { get; set; }

        public virtual string PropertyValue { get; set; }

        public virtual int OperatorId { get; set; }

        public virtual string ResultValue { get; set; }

        public virtual int FunctionId { get; set; }

        public virtual int Period { get; set; } //number of days

        public virtual int UserId { get; set; }

        public virtual string Message { get; set; }
    }
}
