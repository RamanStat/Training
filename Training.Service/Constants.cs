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
            public const string AUTOPART_NAME_COLUMN_NAME = nameof(AUTOPART_NAME_COLUMN_NAME);
            public const string AUTOPART_PRICE_COLUMN_NAME = nameof(AUTOPART_PRICE_COLUMN_NAME);
            public const string AUTOPART_DESCRIPTION_COLUMN_NAME = nameof(AUTOPART_DESCRIPTION_COLUMN_NAME);
            public const string PRODUCER_NAME_COLUMN_NAME = nameof(PRODUCER_NAME_COLUMN_NAME);
            public const string CAR_MODEL_COLUMN_NAME = nameof(CAR_MODEL_COLUMN_NAME);
            public const string CAR_ISSUE_YEAR_COLUMN_NAME = nameof(CAR_ISSUE_YEAR_COLUMN_NAME);
            public const string CAR_ENGINE_COLUMN_NAME = nameof(CAR_ENGINE_COLUMN_NAME);
            public const string VENDOR_NAME_COLUMN_NAME = nameof(VENDOR_NAME_COLUMN_NAME);
        }

        public static class ImportFileColumnNames
        {
            public const int TABLE_ROW_OFFSET = 5;
            public const int COLUMN_COUNT = 8;
            public const string AUTOPART_NAME_COLUMN = "AUTOPART NAME";
            public const string AUTOPART_PRICE_COLUMN = "AUTOPART PRICE";
            public const string AUTOPART_DESCRIPTION_COLUMN = "AUTOPART DESCRIPTION";
            public const string PRODUCER_NAME_COLUMN = "PRODUCER NAME";
            public const string CAR_MODEL_COLUMN = "CAR MODEL";
            public const string CAR_ISSUE_YEAR_COLUMN = "CAR ISSUE YEAR";
            public const string CAR_ENGINE_COLUMN = "CAR ENGINE";
            public const string VENDOR_NAME_COLUMN = "VENDOR NAME";
        }
    }
}
