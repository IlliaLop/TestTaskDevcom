namespace TestTask.BLL.DTO;

public class UpdateOrderDto
{
    public decimal OrderCost { get; set; }
    public string ItemsDescription { get; set; }
    public string ShippingAddress { get; set; }
}