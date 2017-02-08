using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Panel.Models
{ 
    public class StatistiscViewModel
    {

        public new List<SelectListItem> Attributes { get; set; }
        //public Attribute Chosen { get; set; }

        public List<SelectListItem> ChartTypes { get; set; }

        public string CurrentChartType { get; set; }
        public string CurrentAttribute { get; set; }

        public List<String> Labels { get; set; }
        public List<int> CountedData { get; set; }
    
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public class AttributeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AttributeType(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}