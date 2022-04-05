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
    public void AddCustomer(Customer customerToAdd)
    {
        _repo.AddCustomer(customerToAdd);
    }
}