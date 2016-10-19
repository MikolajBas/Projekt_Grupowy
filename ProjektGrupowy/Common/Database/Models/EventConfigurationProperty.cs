namespace Database.Models
{
    public class EventConfigurationProperty
    {
        public int Id { get; set; }

        public int EventConfigurationId { get; set; }

        public int position { get; set; }

        public int PropertyId { get; set; }
    }
}
