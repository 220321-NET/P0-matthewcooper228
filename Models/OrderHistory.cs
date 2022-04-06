// the class will be accessible through the Models namespace
namespace Models;
// class for customer model
public class OrderHistory
{
    public DateTime DatePlaced {get; set;}
    public string? Address {get; set;}
    public string? Name {get; set;}
    public decimal Price {get; set;}
    public int Quantity {get; set;}
}