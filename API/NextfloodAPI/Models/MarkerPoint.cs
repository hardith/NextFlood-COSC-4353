using System;

namespace NextfloodAPI.Models
{
    public class MarkerPoint
    {
        public Int32 ID { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
    }
}
