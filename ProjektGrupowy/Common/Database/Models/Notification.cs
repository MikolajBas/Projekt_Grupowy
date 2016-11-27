using System;

namespace Database.Models
{
    public class Notification : BaseModel<Notification>
    {
        public virtual int Id { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int UserId { get; set; }

        public virtual int NotificationConfigurationId { get; set; }

        public virtual string Message { get; set; }
    }
}
