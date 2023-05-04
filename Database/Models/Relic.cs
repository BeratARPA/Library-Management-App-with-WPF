using System;

namespace Database.Models
{
    public class Relic
    {
        public int RelicId { get; set; }
        public string BookBarcode { get; set; }
        public DateTime RelicDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }

        public int ReaderId { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
