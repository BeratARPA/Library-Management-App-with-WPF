using System.Collections.Generic;

namespace Database.Models
{
    public class PublishingHouse
    {
        public int PublishingHouseId { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
