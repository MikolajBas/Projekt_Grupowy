namespace Database.Models
{
    public class EventConfigurationProperty //for templatre
    {
        public int Id { get; set; }

        public int EventConfigurationId { get; set; }

        public int Position { get; set; } //poistion in html template

        public int PropertyId { get; set; } //datapropertyconfiguration reference
    }
}
