using System;
using System.Collections.Generic;
using Training.SDK.DTO;

namespace Training.Service.EqualityComparers
{
    public class ExcelDTOEqualityComparer : IEqualityComparer<ExcelDTO>
    {
        public bool Equals(ExcelDTO x, ExcelDTO y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return x.AutopartName == y.AutopartName 
                   && x.AutopartPrice.Equals(y.AutopartPrice) 
                   && x.AutopartDescription == y.AutopartDescription 
                   && x.ProducerName == y.ProducerName 
                   && x.CarModel == y.CarModel 
                   && x.CarIssueYear == y.CarIssueYear 
                   && x.CarEngine == y.CarEngine 
                   && x.VendorName == y.VendorName;
        }

        public int GetHashCode(ExcelDTO obj)
        {
            return HashCode.Combine(obj.AutopartName, obj.AutopartPrice, obj.AutopartDescription, 
                obj.ProducerName, obj.CarModel, obj.CarIssueYear, obj.CarEngine, obj.VendorName);
        }
    }
}
