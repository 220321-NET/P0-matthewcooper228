using Models;

namespace BL;

public interface ISLBL
{
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Employee> GetAllEmployees();
    List<Product> GetAllProducts();
    List<InventoryItem> GetAllInventoryItems();
    List<OrderItem> GetAllOrderItems();
    List<Order> GetAllOrders();
    void AddCustomer(Customer customerToAdd);
    void AddNewOrder(Order newOrder);
    void AddNewOrderItem(OrderItem newOrderItem);
    void DecrementInventoryItems(int inventoryItemId, int quantity);
}
