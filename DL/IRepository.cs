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
    void AddCustomer(Customer customerToAdd);
}

