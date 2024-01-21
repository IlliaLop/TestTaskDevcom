namespace TestTask.BLL.DTO;

public class CreateOrderDto
{
    public int UserId { get; set; }
    public decimal OrderCost { get; set; }
    public string ItemsDescription { get; set; }
    public string ShippingAddress { get; set; }
}