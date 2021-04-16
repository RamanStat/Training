using static Training.Service.Constants.ImportFileColumnNames;
using static Training.Service.Constants.ImportFileOffsets;

namespace Training.Service.ExcelValidator
{
    public abstract class ExcelValidator
    {
        protected readonly string[] _cells;

        public ExcelValidator(string[] cells)
        {
            _cells = cells;
        }

        public abstract void ValidateColumnNames();

        protected virtual string ValidateAutopartName()
        {
            if (_cells[AUTOPART_NAME_COLUMN_OFFSET] == AUTOPART_NAME_COLUMN) return null;
            
            return $"Number of column {AUTOPART_NAME_COLUMN_OFFSET} must be " +
                   $"named as {AUTOPART_NAME_COLUMN}. Your name is {_cells[AUTOPART_NAME_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateAutopartPrice()
        {
            if (_cells[AUTOPART_PRICE_COLUMN_OFFSET] == AUTOPART_PRICE_COLUMN) return null;

            return $"Number of column {AUTOPART_PRICE_COLUMN_OFFSET} must be " +
                   $"named as {AUTOPART_PRICE_COLUMN}. Your name is {_cells[AUTOPART_PRICE_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateAutopartDescription()
        {
            if (_cells[AUTOPART_DESCRIPTION_COLUMN_OFFSET] == AUTOPART_DESCRIPTION_COLUMN) return null;

            return $"Number of column {AUTOPART_DESCRIPTION_COLUMN_OFFSET} must be " +
                   $"named as {AUTOPART_DESCRIPTION_COLUMN}. Your name is {_cells[AUTOPART_DESCRIPTION_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateProducerName()
        {
            if (_cells[PRODUCER_NAME_COLUMN_OFFSET] == PRODUCER_NAME_COLUMN) return null;

            return $"Number of column {PRODUCER_NAME_COLUMN_OFFSET} must be " +
                   $"named as {PRODUCER_NAME_COLUMN}. Your name is {_cells[PRODUCER_NAME_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateCarModel()
        {
            if (_cells[CAR_MODEL_COLUMN_OFFSET] == CAR_MODEL_COLUMN) return null;

            return $"Number of column {CAR_MODEL_COLUMN_OFFSET} must be " +
                   $"named as {CAR_MODEL_COLUMN}. Your name is {_cells[CAR_MODEL_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateCarIssuerYear()
        {
            if (_cells[CAR_ISSUE_YEAR_COLUMN_OFFSET] == CAR_ISSUE_YEAR_COLUMN) return null;

            return $"Number of column {CAR_ISSUE_YEAR_COLUMN_OFFSET} must be " +
                   $"named as {CAR_ISSUE_YEAR_COLUMN}. Your name is {_cells[CAR_ISSUE_YEAR_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateCarEngine()
        {
            if (_cells[CAR_ENGINE_COLUMN_OFFSET] == CAR_ENGINE_COLUMN) return null;

            return $"Number of column {CAR_ENGINE_COLUMN_OFFSET} must be " +
                   $"named as {CAR_ENGINE_COLUMN}. Your name is {_cells[CAR_ENGINE_COLUMN_OFFSET]}";
        }

        protected virtual string ValidateVendorName()
        {
            if (_cells[VENDOR_NAME_COLUMN_OFFSET] == VENDOR_NAME_COLUMN) return null;

            return $"Number of column {VENDOR_NAME_COLUMN_OFFSET} must be " +
                   $"named as {VENDOR_NAME_COLUMN}. Your name is {_cells[VENDOR_NAME_COLUMN_OFFSET]}";
        }
    }
}
