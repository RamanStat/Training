﻿using System.Collections.Generic;

namespace Training.Data.Entities
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Autopart> Autoparts { get; set; } = new List<Autopart>();
    }
}
