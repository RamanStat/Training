using AutoMapper;
using ExcelDataReader;
using Training.SDK.DTO;

namespace Training.SDK.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IExcelDataReader, ExcelDTO>()
                .ForMember(e => e.AutopartName, source => source.MapFrom(s => s.GetValue(0)))
                .ForMember(e => e.AutopartPrice, source => source.MapFrom(s => double.Parse(s.GetValue(1).ToString())))
                .ForMember(e => e.AutopartDescription, source => source.MapFrom(s => s.GetValue(2)))
                .ForMember(e => e.ProducerName, source => source.MapFrom(s => s.GetValue(3)))
                .ForMember(e => e.CarModel, source => source.MapFrom(s => s.GetValue(4)))
                .ForMember(e => e.CarIssueYear, source => source.MapFrom(s => int.Parse(s.GetValue(5).ToString())))
                .ForMember(e => e.CarEngine, source => source.MapFrom(s => int.Parse(s.GetValue(6).ToString())))
                .ForMember(e => e.VendorName, source => source.MapFrom(s => s.GetValue(7)))
                .ReverseMap();
        }
    }
}
