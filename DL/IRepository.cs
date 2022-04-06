using Models;
namespace DL;
/// <summary>
/// Interface for accessing data in P0
/// </summary>
public interface IRepository
{

    public List<Customer> GetAllCustomers();
    public List<Store> GetAllStores();
    public List<Employee> GetAllEmployees();
    public List<Product> GetAllProducts();
    public List<InventoryItem> GetAllInventoryItems();
    public List<OrderItem> GetAllOrderItems();
    public List<Order> GetAllOrders();
    void AddCustomer(Customer customerToAdd);
    void AddNewOrder(Order newOrder);
    void AddNewOrderItem(OrderItem newOrderItem);
    void DecrementInventoryItems(int inventoryItemId, int quantity);

}

