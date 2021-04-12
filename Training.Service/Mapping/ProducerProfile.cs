using AutoMapper;
using ExcelDataReader;
using Training.Data.Entities;
using Training.SDK.DTO;

namespace Training.Service.Mapping
{
    public class ProducerProfile : Profile
    {
        public ProducerProfile()
        {
            CreateMap<ProducerDTO, Producer>()
                .ReverseMap();
        }
    }
}
