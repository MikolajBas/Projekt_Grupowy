using System;

namespace Database.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public int NotificationConfigurationId { get; set; }

        public string Message { get; set; }
    }
}
