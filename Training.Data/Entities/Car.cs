using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Engine { get; set; }

        public int IssueYear { get; set; }

        public ICollection<Autopart> Autoparts { get; set; } = new List<Autopart>();
    }
}
