using System;

namespace Database.Models
{
    public class Data
    {
        public int Id { get; set; }

        public string Ip { get; set; }

        public string Url { get; set; }

        public string Browser { get; set; }

        public string System { get; set; }

        public string ScreenResolution { get; set; }

        public string Agent { get; set; } //desktop/mobile

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public DateTime Date { get; set; }
    }
}
