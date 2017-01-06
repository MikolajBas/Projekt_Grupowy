using Data.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Range(-100, int.MaxValue)]
        public int PropertyId { get; set; }

        public IEnumerable<SelectListItem> PropertyList { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PropertyOperator { get; set; }
        
        public IEnumerable<SelectListItem> PropertyOperatorList { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PropertyValue { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Operator { get; set; }

        public IEnumerable<SelectListItem> OperatorList { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public string ResultValue { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Function { get; set; }

        public IEnumerable<SelectListItem> FunctionList { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public string Period { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Html)]
        public string Template { get; set; }
    }
}
