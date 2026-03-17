using AutoMapper;
using SmartRepairApi.Models;
using SmartRepairApi.Dtos.Client;
using SmartRepairApi.Dtos.Repair;
using SmartRepairApi.Dtos.Technician;
using SmartRepairApi.Dtos.RepairHistory;

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

            // Technician
            CreateMap<Technician, TechnicianDto>();

            // RepairHistory
            CreateMap<RepairHistory, RepairHistoryDto>();

            // Repair
            CreateMap<Repair, RepairDto>();
            CreateMap<RepairCreateDto, Repair>();
            CreateMap<RepairUpdateDto, Repair>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
