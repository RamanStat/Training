using AutoMapper;
using ExcelDataReader;
using Training.SDK.DTO;

namespace Training.Service.Mapping
{
    public class ExcelProfile : Profile
    {
        public ExcelProfile()
        {
            CreateMap<IExcelDataReader, ExcelDTO>()
                .ForMember(e => e.AutopartName, source => source.MapFrom(s => s.GetValue(Constants.ImportFileOffsets.AutopartName_COLUMN_OFFSET)))
                .ForMember(e => e.AutopartPrice, source => source.MapFrom(s => double.Parse(s.GetValue(Constants.ImportFileOffsets.AutopartPrice_COLUMN_OFFSET).ToString())))
                .ForMember(e => e.AutopartDescription, source => source.MapFrom(s => s.GetValue(Constants.ImportFileOffsets.AutopartDescription_COLUMN_OFFSET)))
                .ForMember(e => e.ProducerName, source => source.MapFrom(s => s.GetValue(Constants.ImportFileOffsets.Producer_NameCOLUMN_OFFSET)))
                .ForMember(e => e.CarModel, source => source.MapFrom(s => s.GetValue(Constants.ImportFileOffsets.CarModel_COLUMN_OFFSET)))
                .ForMember(e => e.CarIssueYear, source => source.MapFrom(s => int.Parse(s.GetValue(Constants.ImportFileOffsets.CarIssueYear_COLUMN_OFFSET).ToString())))
                .ForMember(e => e.CarEngine, source => source.MapFrom(s => int.Parse(s.GetValue(Constants.ImportFileOffsets.CarEngine_COLUMN_OFFSET).ToString())))
                .ForMember(e => e.VendorName, source => source.MapFrom(s => s.GetValue(Constants.ImportFileOffsets.VendorName_COLUMN_OFFSET)))
                .ReverseMap();
        }
    }
}
