using System;

namespace Database.Models
{
    public class Data : BaseModel<Data>
    {
        public virtual int Id { get; set; }

        public virtual string Ip { get; set; }

        public virtual string Url { get; set; }

        public virtual string Browser { get; set; }

        public virtual string System { get; set; }

        public virtual string ScreenResolution { get; set; }

        public virtual string Agent { get; set; } //desktop/mobile

        public virtual int UserId { get; set; }

        public virtual string Category { get; set; }

        public virtual int ProductId { get; set; }

        public virtual string ProductName { get; set; }

        public virtual DateTime Date { get; set; }
    }
}
