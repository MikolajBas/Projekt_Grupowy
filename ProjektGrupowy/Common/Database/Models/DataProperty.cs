namespace Database.Models
{
    public class DataProperty //its store properties define by configuration
    {
        public int Id { get; set; }

        public int PropertyId { get; set; } //datapropertieconfigurationId

        public string Value { get; set; }

        public int DataId { get; set; } //reference to data
    }
}
