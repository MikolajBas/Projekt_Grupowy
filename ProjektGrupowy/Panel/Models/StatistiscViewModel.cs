using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Panel.Models
{ 
    public class StatistiscViewModel
    {

        public List<AttributeType> Attributes { get; set; }

        public List<AttributeType> ChartTypes { get; set; }

        public AttributeType CurrentChartType;
        public AttributeType CurrentAttribute;

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