﻿using System.Collections.Generic;

namespace Training.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Engine { get; set; }

        public int IssueYear { get; set; }

        public ICollection<Autopart> Autoparts { get; set; } = new List<Autopart>();
    }
}
