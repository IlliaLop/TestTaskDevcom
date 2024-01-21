using AutoMapper;
using TestTask.BLL.DTO;
using TestTask.DAL.Entities;

namespace TestTask.BLL.MappingProfiles;

public class OrderProfile: Profile
{
    public OrderProfile()
    {
        CreateMap<Order, CreateOrderDto>()!.ReverseMap();
        CreateMap<Order, UpdateOrderDto>()!.ReverseMap();
        CreateMap<Order, OrderDto>()!.ReverseMap();
    }
}