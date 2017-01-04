using Data.Data;
using Database.Models;
using System.Collections.Generic;

namespace Panel.Models
{
    public class EventConfigurationViewModel
    {
        public List<EventConfigRow> Configurations { get; set; }

        public List<UserDataProperty> Properties { get; set; }

        public EventConfiguration CurrentConfig { get; set; }

        public string Response { get; set; }
    }

    public class EventConfigRow
    {
        public int Id { get; set; }
        
        public string Rule { get; set; }

        public int Period { get; set; }
    }
}
