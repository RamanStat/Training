using System.Collections.Generic;

namespace Data.Entities
{
    public class Autopart
    {
        public int Id { get; set; }

        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>(); 
    }
}
