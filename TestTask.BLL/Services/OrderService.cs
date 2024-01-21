using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BLL.DTO;
using TestTask.BLL.Exceptions;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Context;
using TestTask.DAL.Entities;

namespace TestTask.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly TestTaskContext _context;
    public OrderService(TestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDto> GetOrderAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        ValidateOrder(order);

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var user = await _context.Users.FindAsync(createOrderDto.UserId);
        
        ValidateUser(user, createOrderDto.UserId);
        
        bool orderExists = await _context.Orders
            .AnyAsync(o => o.UserId == createOrderDto.UserId && o.OrderDate.Date == DateTime.UtcNow.Date);

        if (orderExists)
        {
            throw new OrderCreationException(nameof(orderExists));
        }
        
        var order = _mapper.Map<Order>(createOrderDto);
        order.OrderDate = DateTime.UtcNow;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto)
    {
        var order = await _context.Orders.FindAsync(orderId);

        ValidateOrder(order);

        _mapper.Map(updateOrderDto, order);

        await _context.SaveChangesAsync();

        return _mapper.Map<OrderDto>(order);
    }
    
    private void ValidateOrder(Order? order)
    {
        if (order is null)
        {
            throw new EntityNotFoundException(nameof(order));
        }
    }
    
    private void ValidateUser(User? user, int userId)
    {
        if (user is null)
        {
            throw new EntityNotFoundException(nameof(user), userId);
        }
    }
}