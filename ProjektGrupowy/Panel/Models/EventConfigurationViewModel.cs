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

        public IEnumerable<SelectListItem> Property { get; set; }

        public IEnumerable<SelectListItem> PropertyOperator { get; set; }

        public string PropertyValue { get; set; }

        public IEnumerable<SelectListItem> Operator { get; set; }

        public string ResultValue { get; set; }

        public IEnumerable<SelectListItem> Function { get; set; }

        public string Period { get; set; }

        public string Template { get; set; }
    }
}
