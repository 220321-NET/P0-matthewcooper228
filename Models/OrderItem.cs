// the class will be accessible through the Models namespace
namespace Models;
// class for line item model
public class OrderItem
{
    public int Id {get; set;}
    public int OrderId {get; set;}
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}