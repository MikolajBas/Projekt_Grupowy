namespace Database.Models
{
    public class EventConfigurationProperty
    {
        public virtual int Id { get; set; }

        public virtual int EventConfigurationId { get; set; }

        public virtual int Position { get; set; }

        public virtual int PropertyId { get; set; }
    }
}
