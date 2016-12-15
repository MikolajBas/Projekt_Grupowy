namespace Database.Models
{
    public class EventConfiguration //event describes clinent "interaction"
    {
        public int Id { get; set; }

        public int PropertyId { get; set; } // reference to dataPropertiesConfiguration reference

        public string PropertyOperator { get; set; } //< > = filter operator

        public string PropertyValue { get; set; } // filter by value

        public string Operator { get; set; } //aggregate function comparison with result value, < > =

        public int ResultValue { get; set; } //expected result

        public string Function { get; set; } //aggregation fuction sum count etc

        public int Period { get; set; } //number of days

        public int UserId { get; set; } 

        public string Template { get; set; } //html template

        public int CategoryId { get; set; } //dataCategory refernce
    }
}
