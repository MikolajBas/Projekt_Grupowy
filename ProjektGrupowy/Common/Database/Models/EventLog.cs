using System;

namespace Database.Models
{
    public class EventLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Ip { get; set; }

        public int EventConfigurationId { get; set; }

        public DateTime Date { get; set; }
    }
}
