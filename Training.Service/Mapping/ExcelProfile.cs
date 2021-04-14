using AutoMapper;
using Training.SDK.DTO;

namespace Training.Service.Mapping
{
    public class ExcelProfile : Profile
    {
        public ExcelProfile()
        {
            CreateMap<string[], ExcelDTO>()
                .ForMember(e => e.AutopartName, source => source.MapFrom(s => s[Constants.ImportFileOffsets.AUTOPARTNAME_COLUMN_OFFSET]))
                .ForMember(e => e.AutopartPrice, source => source.MapFrom(s => double.Parse(s[Constants.ImportFileOffsets.AUTOPARTPRICE_COLUMN_OFFSET])))
                .ForMember(e => e.AutopartDescription, source => source.MapFrom(s => s[Constants.ImportFileOffsets.AUTOPARTDESCRIPTION_COLUMN_OFFSET]))
                .ForMember(e => e.ProducerName, source => source.MapFrom(s => s[Constants.ImportFileOffsets.PRODUCERNAME_COLUMN_OFFSET]))
                .ForMember(e => e.CarModel, source => source.MapFrom(s => s[Constants.ImportFileOffsets.CARMODEL_COLUMN_OFFSET]))
                .ForMember(e => e.CarIssueYear, source => source.MapFrom(s => int.Parse(s[Constants.ImportFileOffsets.CARISSUEYEAR_COLUMN_OFFSET])))
                .ForMember(e => e.CarEngine, source => source.MapFrom(s => int.Parse(s[Constants.ImportFileOffsets.CARENGINE_COLUMN_OFFSET])))
                .ForMember(e => e.VendorName, source => source.MapFrom(s => s[Constants.ImportFileOffsets.VENDORNAME_COLUMN_OFFSET]))
                .ReverseMap();
        }
    }
}
