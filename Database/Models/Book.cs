using System;

namespace Database.Models
{
    public class Book
    {
        public int BookId { get; set; }         
        public string Name { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public string PrintingPlace { get; set; }
        public int PrintCount { get; set; }
        public DateTime PrintDate { get; set; }
        public string SupplyCategory { get; set; }
        public DateTime SupplyDate { get; set; }
        public int PageCount { get; set; }
        public string Image { get; set; }
        public string Barcode { get; set; }
        public bool RelicStatus { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public int PublishingHouseId { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
    }
}
