using System;
using System.Collections.Generic;
using Training.SDK.DTO;

namespace Training.SDK.EqualityComparers
{
    public class ProducerDTOEquilityComparer : IEqualityComparer<ProducerDTO>
    {
        public bool Equals(ProducerDTO x, ProducerDTO y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return x.Id == y.Id && x.Name == y.Name && x.Address == y.Address && x.Phone == y.Phone;
        }

        public int GetHashCode(ProducerDTO obj)
        {
            return HashCode.Combine(obj.Id, obj.Name, obj.Address, obj.Phone);
        }
    }
}
