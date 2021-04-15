using System;
using static Training.Service.Constants.ImportFileOffsets;
using static Training.Service.Constants.ImportFileStructure;

namespace Training.Service.EqualityComparers
{
    public class ExcelColumnNamesEqualityComparer : IEquatable<string[]>
    {
        public bool Equals(string[] x)
        {
            if (x == null || x.Length != COLUMN_COUNT)
            {
                return false;
            }
            
            return x[AUTOPART_NAME_COLUMN_OFFSET] == AUTOPARTNAME_COLUMN_NAME[..AUTOPARTNAME_COLUMN_NAME.IndexOf('_')]
                   && x[AUTOPART_PRICE_COLUMN_OFFSET] == AUTOPARTPRICE_COLUMN_NAME[..AUTOPARTPRICE_COLUMN_NAME.IndexOf('_')]
                   && x[AUTOPART_DESCRIPTION_COLUMN_OFFSET] == AUTOPARTDESCRIPTION_COLUMN_NAME[..AUTOPARTDESCRIPTION_COLUMN_NAME.IndexOf('_')]
                   && x[PRODUCER_NAME_COLUMN_OFFSET] == PRODUCERNAME_COLUMN_NAME[..PRODUCERNAME_COLUMN_NAME.IndexOf('_')]
                   && x[CAR_MODEL_COLUMN_OFFSET] == CARMODEL_COLUMN_NAME[..CARMODEL_COLUMN_NAME.IndexOf('_')]
                   && x[CAR_ISSUE_YEAR_COLUMN_OFFSET] == CARISSUEYEAR_COLUMN_NAME[..CARISSUEYEAR_COLUMN_NAME.IndexOf('_')]
                   && x[CAR_ENGINE_COLUMN_OFFSET] == CARENGINE_COLUMN_NAME[..CARENGINE_COLUMN_NAME.IndexOf('_')]
                   && x[VENDOR_NAME_COLUMN_OFFSET] == VENDORNAME_COLUMN_NAME[..VENDORNAME_COLUMN_NAME.IndexOf('_')];
        }
    }
}
