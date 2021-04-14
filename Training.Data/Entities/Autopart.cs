using System.Collections.Generic;

namespace Training.Data.Entities
{
    public class Autopart
    {
        public int Id { get; set; }

        public int ProducerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Producer Producer { get; set; }
        
        public ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();

        public ICollection<Car> Cars { get; set; } = new List<Car>(); 
    }
}
