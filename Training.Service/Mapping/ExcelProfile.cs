using AutoMapper;
using Training.Data.Entities;
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

            CreateMap<ExcelDTO, Autopart>()
                .ForMember(a => a.Name, source => source.MapFrom(s => s.AutopartName))
                .ForMember(a => a.Description, source => source.MapFrom(s => s.AutopartDescription))
                .ForMember(a => a.Price, source => source.MapFrom(s => s.AutopartPrice))
                .ForAllOtherMembers(s => s.Ignore());
        }
    }
}
