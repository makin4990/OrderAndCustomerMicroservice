using AutoMapper;
using CoreFramework.Persistence.Paging;
using Ordering.Application.Features.Orders.Commands.ChangeOrderStatus;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Dtos;
using Ordering.Application.Features.Orders.Models;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IPaginate<Order>, OrderListModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<Order, OrderListModelDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        
        CreateMap<CreateOrderCommand, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<UpdateOrderCommand, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<DeleteOrderCommand, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<ChangeOrderStatusCommand, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));

        CreateMap<OrderDto, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<CreateOrderDto, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<UpdateOrderDto, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<ChangeOrderStatusDto, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<DeleteOrderDto, Order>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
       
        CreateMap<CreateProductDto, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));
        CreateMap<UpdateProductDto, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src is not null));

    }
}
