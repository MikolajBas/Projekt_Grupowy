namespace Database.Models
{
    public class EventConfiguration : BaseModel<EventConfiguration>
    {
        public virtual int Id { get; set; }

        public virtual int PropertyId { get; set; }

        public virtual string PropertyOperator { get; set; }

        public virtual string PropertyValue { get; set; }

        public virtual string Operator { get; set; }

        public virtual int ResultValue { get; set; }

        public virtual string Function { get; set; }

        public virtual int Period { get; set; } //number of days

        public virtual int UserId { get; set; }

        public virtual string Template { get; set; }

        public virtual string Category { get; set; }
    }
}
