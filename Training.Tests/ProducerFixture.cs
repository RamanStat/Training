using System.Collections.Generic;
using Training.Data.Entities;

namespace Training.Tests
{
    public class ProducerFixture
    {
        private readonly List<Producer> _producers;

        public ProducerFixture()
        {
            _producers = new List<Producer>()
            {
                new()
                {
                    Id = 1,
                    Name = "test",
                    Address = "test",
                    Phone = "test"
                },
                new()
                {
                    Id = 2,
                    Name = "test",
                    Address = "test",
                    Phone = "test"
                }
            };
        }
        
        public Producer GetProducer(int id)
        {
            return _producers[id];
        }

        public IEnumerable<Producer> GetProducers()
        {
            return _producers;
        }
    }
}
