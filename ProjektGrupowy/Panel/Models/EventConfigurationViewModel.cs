using System.Collections.Generic;

namespace Panel.Models
{
    public class EventConfigurationViewModel
    {
        public List<EventConfigRow> Configurations { get; set; }

        public List<string> Properties { get; set; }
    }

    public class EventConfigRow
    {
        public int Id { get; set; }
        
        public string Rule { get; set; }

        public int Period { get; set; }
    }
}
