using System;

namespace Database.Models
{
    public class EventLog
    {
        public virtual int Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual string Ip { get; set; }

        public virtual int EventConfigurationId { get; set; }

        public virtual DateTime Date { get; set; }
    }
}
