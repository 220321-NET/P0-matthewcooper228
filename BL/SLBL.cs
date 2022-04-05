using DL;
using Models;
namespace BL;
public class SLBL : ISLBL
{
    private readonly IRepository _repo;
    public SLBL(IRepository repo)
    {
        _repo = repo;
    }
    public List<Customer> GetAllCustomers()
    {
        return _repo.GetAllCustomers();
    }
    public List<Store> GetAllStores()
    {
        return _repo.GetAllStores();
    }
    public List<Employee> GetAllEmployees()
    {
        return _repo.GetAllEmployees();
    }
    public List<Product> GetAllProducts()
    {
        return _repo.GetAllProducts();
    }
    public List<InventoryItem> GetAllInventoryItems()
    {
        return _repo.GetAllInventoryItems();
    }
    public List<OrderItem> GetAllOrderItems()
    {
        return _repo.GetAllOrderItems();
    }
    public List<Order> GetAllOrders()
    {
        return _repo.GetAllOrders();
    }
    public void AddCustomer(Customer customerToAdd)
    {
        _repo.AddCustomer(customerToAdd);
    }
}