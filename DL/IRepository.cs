using Models;
namespace DL;
/// <summary>
/// Interface for accessing data in P0
/// </summary>
public interface IRepository
{
    public List<Customer> GetAllExistingCustomers();
    void AddCustomer(Customer customerToAdd);
}

