namespace TestTask.DAL.Entities;

public class Order
{
    public int OrderId { get; set; }
        
    public int UserId { get; set; }
        
    public DateTime OrderDate { get; set; }
        
    public decimal OrderCost { get; set; }
        
    public string ItemsDescription { get; set; } = string.Empty;
        
    public string ShippingAddress { get; set; } = string.Empty;

    public User User { get; set; }
}