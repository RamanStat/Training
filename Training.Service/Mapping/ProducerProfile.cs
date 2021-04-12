using AutoMapper;
using Training.Data.Entities;
using Training.SDK.DTO;

namespace Training.Service.Mapping
{
    public class ProducerProfile : Profile
    {
        public ProducerProfile()
        {
            CreateMap<ProducerDTO, Producer>()
                .ForMember(p => p.Autoparts, source => source.Ignore())
                .ReverseMap();
        }
    }
}
