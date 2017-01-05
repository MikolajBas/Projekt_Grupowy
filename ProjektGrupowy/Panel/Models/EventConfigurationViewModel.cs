using Data.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Panel.Models
{
    public class EventConfigurationViewModel
    {
        public List<EventConfigRow> Configurations { get; set; }

        public List<UserDataProperty> Properties { get; set; }

        public CurrentConfig CurrentConfig { get; set; }

        public string Response { get; set; }
    }

    public class EventConfigRow
    {
        public int Id { get; set; }
        
        public string Rule { get; set; }

        public int Period { get; set; }
    }

    public class CurrentConfig
    {
        public string Id { get; set; }

        public int PropertyId { get; set; }

        public IEnumerable<SelectListItem> PropertyList { get; set; }

        public string PropertyOperator { get; set; }
        
        public IEnumerable<SelectListItem> PropertyOperatorList { get; set; }

        public string PropertyValue { get; set; }

        public string Operator { get; set; }

        public IEnumerable<SelectListItem> OperatorList { get; set; }

        public string ResultValue { get; set; }

        public string Function { get; set; }

        public IEnumerable<SelectListItem> FunctionList { get; set; }

        public string Period { get; set; }

        public string Template { get; set; }
    }
}
