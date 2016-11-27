namespace Database.Models
{
    public class DataProperty : BaseModel<DataProperty>
    {
        public virtual int Id { get; set; }

        public virtual int PropertyId { get; set; }

        public virtual string Value { get; set; }

        public virtual int DataId { get; set; }
    }
}
