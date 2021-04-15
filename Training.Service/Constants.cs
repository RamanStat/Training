namespace Training.Service
{
    public class Constants
    {
        public static class ImportFileOffsets
        {
            public const int AUTOPART_NAME_COLUMN_OFFSET = 0;
            public const int AUTOPART_PRICE_COLUMN_OFFSET = 1;
            public const int AUTOPART_DESCRIPTION_COLUMN_OFFSET = 2;
            public const int PRODUCER_NAME_COLUMN_OFFSET = 3;
            public const int CAR_MODEL_COLUMN_OFFSET = 4;
            public const int CAR_ISSUE_YEAR_COLUMN_OFFSET = 5;
            public const int CAR_ENGINE_COLUMN_OFFSET = 6;
            public const int VENDOR_NAME_COLUMN_OFFSET = 7;
        }

        public static class ImportFileStructure
        {
            public const int COLUMN_COUNT = 8;
            public const string VALID_COLUMN_ORDER_WITH_NAMES =
                "AUTOPARTNAME-AUTOPARTPRICE-AUTOPARTDESCRIPTION-PRODUCERNAME-CARMODEL-CARISSUEYEAR-CARENGINE-VENDORNAME";
            public const string AUTOPARTNAME_COLUMN_NAME = nameof(AUTOPARTNAME_COLUMN_NAME);
            public const string AUTOPARTPRICE_COLUMN_NAME = nameof(AUTOPARTPRICE_COLUMN_NAME);
            public const string AUTOPARTDESCRIPTION_COLUMN_NAME = nameof(AUTOPARTDESCRIPTION_COLUMN_NAME);
            public const string PRODUCERNAME_COLUMN_NAME = nameof(PRODUCERNAME_COLUMN_NAME);
            public const string CARMODEL_COLUMN_NAME = nameof(CARMODEL_COLUMN_NAME);
            public const string CARISSUEYEAR_COLUMN_NAME = nameof(CARISSUEYEAR_COLUMN_NAME);
            public const string CARENGINE_COLUMN_NAME = nameof(CARENGINE_COLUMN_NAME);
            public const string VENDORNAME_COLUMN_NAME = nameof(VENDORNAME_COLUMN_NAME);
        }
    }
}
