using AutoMapper;
using SmartRepairApi.Models;
using SmartRepairApi.Dtos.Client;
using SmartRepairApi.Dtos.Repair;

namespace SmartRepairApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Client
            CreateMap<Client, ClientDto>();
            CreateMap<ClientCreateDto, Client>();
            CreateMap<ClientUpdateDto, Client>();

            // Repair
            CreateMap<Repair, RepairDto>();
            CreateMap<RepairCreateDto, Repair>();
            CreateMap<RepairUpdateDto, Repair>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
