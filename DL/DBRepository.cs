using Microsoft.Data.SqlClient;
using System.Data;
using Models;

namespace DL;

public class DBRepository : IRepository
{
    private readonly string _connectionString;
    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    /// <summary>
    /// Returns a list of all existing customers
    /// </summary>
    /// <returns></returns>
    public List<Customer> GetAllExistingCustomers()
    {
        List<Customer> allExistingCustomers = new List<Customer>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string userName = reader.GetString(1);
            Customer customer = new Customer{
                Id = id,
                UserName = userName
            };
            allExistingCustomers.Add(customer);
        }

        return allExistingCustomers;
    }
    public void AddCustomer(Customer customerToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("INSERT INTO Customers(UserName) OUTPUT INSERTED.Id VALUES (@userName)", connection);

        cmd.Parameters.AddWithValue("@userName", customerToAdd.UserName);

        // Risky code, SQL Injection
        // using SqlCommand cmd2 = new SqlCommand($"INSERT INTO Issues(Title, Content, DateCreated) VALUES ({issueToCreate.Title}, {issueToCreate.Content}, {issueToCreate.DateCreated})", connection);
        try
        {
            customerToAdd.Id = (int) cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        connection.Close();
    }
}