using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces;

namespace TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController: ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetOrderAsync(int orderId)
    {
        return Ok(await _orderService.GetOrderAsync(orderId));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        return Ok(await _orderService.CreateOrderAsync(createOrderDto));
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] UpdateOrderDto updateOrderDto)
    {
        return Ok(await _orderService.UpdateOrderAsync(orderId, updateOrderDto));
    }
}