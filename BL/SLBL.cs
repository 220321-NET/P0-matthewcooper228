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
    public List<Customer> GetAllExistingCustomers()
    {
        return _repo.GetAllExistingCustomers();
    }
    public void AddCustomer(Customer customerToAdd)
    {

    }

}