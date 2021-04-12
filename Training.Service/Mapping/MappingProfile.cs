using AutoMapper;
using ExcelDataReader;
using Training.Data.Entities;
using Training.SDK.DTO;

namespace Training.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProducerDTO, Producer>()
                .ReverseMap();

            CreateMap<IExcelDataReader, ExcelDTO>()
                .ForMember(e => e.AutopartName, source => source.MapFrom(s => s.GetValue((int)Constants.AutopartName)))
                .ForMember(e => e.AutopartPrice, source => source.MapFrom(s => double.Parse(s.GetValue((int)Constants.AutopartPrice).ToString())))
                .ForMember(e => e.AutopartDescription, source => source.MapFrom(s => s.GetValue((int)Constants.AutopartDescription)))
                .ForMember(e => e.ProducerName, source => source.MapFrom(s => s.GetValue((int)Constants.ProducerName)))
                .ForMember(e => e.CarModel, source => source.MapFrom(s => s.GetValue((int)Constants.CarModel)))
                .ForMember(e => e.CarIssueYear, source => source.MapFrom(s => int.Parse(s.GetValue((int)Constants.CarIssueYear).ToString())))
                .ForMember(e => e.CarEngine, source => source.MapFrom(s => int.Parse(s.GetValue((int)Constants.CarEngine).ToString())))
                .ForMember(e => e.VendorName, source => source.MapFrom(s => s.GetValue((int)Constants.VendorName)))
                .ReverseMap();
        }
    }
}
