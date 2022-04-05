// the class will be accessible through the Models namespace
namespace Models;
// class for order model
public class Order
{
    public int Id { get; set;}
    public int CustomerId {get; set;}
    public int StoreId {get; set;}
    public DateTime DatePlaced {get; set;}
}