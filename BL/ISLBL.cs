using Models;

namespace BL;

public interface ISLBL
{
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Employee> GetAllEmployees();
    void AddCustomer(Customer customerToAdd);
}
