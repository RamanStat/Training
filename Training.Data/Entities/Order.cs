using System;

namespace Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int AutopartId { get; set; }

        public Autopart Autopart { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
