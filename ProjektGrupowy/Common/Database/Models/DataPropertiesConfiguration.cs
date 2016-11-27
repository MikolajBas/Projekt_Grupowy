namespace Database.Models
{
    public class DataPropertiesConfiguration : BaseModel<DataPropertiesConfiguration>
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int TypeId { get; set; }

        public virtual int UserId { get; set; }
    }
}
