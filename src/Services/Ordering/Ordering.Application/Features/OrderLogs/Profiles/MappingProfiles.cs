using AutoMapper;
using CoreFramework.Persistence.Paging;
using Ordering.Application.Features.OrderLogs.Dtos;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.OrderLogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OrderLog, OrderLogDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));

    }
}