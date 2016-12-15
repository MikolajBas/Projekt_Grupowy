namespace Database.Models
{
    public class DataPropertiesConfiguration //additiona info about product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; } // tpyeof The property string int datatime

        public int UserId { get; set; }
    }
}
