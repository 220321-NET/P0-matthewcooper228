// the class will be accessible through the Models namespace
namespace Models;
// class for line item model
public class InventoryItem
{
 public int Id { get; set;}
 public int StoreId {get; set;}
 public int ProductId { get; set; }
 public int Quantity { get; set; }
}