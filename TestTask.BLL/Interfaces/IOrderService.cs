using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces;

public interface IOrderService
{
    Task<OrderDto> GetOrderAsync(int orderId);
    Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<OrderDto> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto);
}