using AutoMapper;
using Training.Data.Entities;
using Training.SDK.DTO;
using static Training.Service.Constants.ImportFileOffsets;

namespace Training.Service.Mapping
{
    public class ExcelProfile : Profile
    {
        public ExcelProfile()
        {
            CreateMap<string[], ExcelDTO>()
                .ForMember(e => e.AutopartName, source => source.MapFrom(s => s[AUTOPART_NAME_COLUMN_OFFSET]))
                .ForMember(e => e.AutopartPrice, source => source.MapFrom(s => double.Parse(s[AUTOPART_PRICE_COLUMN_OFFSET])))
                .ForMember(e => e.AutopartDescription, source => source.MapFrom(s => s[AUTOPART_DESCRIPTION_COLUMN_OFFSET]))
                .ForMember(e => e.ProducerName, source => source.MapFrom(s => s[PRODUCER_NAME_COLUMN_OFFSET]))
                .ForMember(e => e.CarModel, source => source.MapFrom(s => s[CAR_MODEL_COLUMN_OFFSET]))
                .ForMember(e => e.CarIssueYear, source => source.MapFrom(s => int.Parse(s[CAR_ISSUE_YEAR_COLUMN_OFFSET])))
                .ForMember(e => e.CarEngine, source => source.MapFrom(s => int.Parse(s[CAR_ENGINE_COLUMN_OFFSET])))
                .ForMember(e => e.VendorName, source => source.MapFrom(s => s[VENDOR_NAME_COLUMN_OFFSET]))
                .ReverseMap();

            CreateMap<ExcelDTO, Autopart>()
                .ForMember(a => a.Name, source => source.MapFrom(s => s.AutopartName))
                .ForMember(a => a.Description, source => source.MapFrom(s => s.AutopartDescription))
                .ForMember(a => a.Price, source => source.MapFrom(s => s.AutopartPrice))
                .ForAllOtherMembers(s => s.Ignore());
        }
    }
}
