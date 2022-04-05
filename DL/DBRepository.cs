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
    public List<Customer> GetAllCustomers()
    {
        List<Customer> allCustomers = new List<Customer>();
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
            allCustomers.Add(customer);
        }
        reader.Close();
        connection.Close();
        return allCustomers;
    }

    public List<Store> GetAllStores()
    {
        List<Store> allStores = new List<Store>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Stores", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string address = reader.GetString(1);
            Store store = new Store{
                Id = id,
                Address = address
            };
            allStores.Add(store);
        }
        reader.Close();
        connection.Close();
        return allStores;
    }
    public List<Employee> GetAllEmployees()
    {
        List<Employee> allEmployees = new List<Employee>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            Employee employee = new Employee{
                Id = id
            };
            allEmployees.Add(employee);
        }
        reader.Close();
        connection.Close();
        return allEmployees;
    }
    public List<Product> GetAllProducts()
    {
        List<Product> allProducts = new List<Product>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Products", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            decimal price = reader.GetDecimal(2);
            Product product = new Product{
                Id = id,
                Name = name,
                Price = price
            };
            allProducts.Add(product);
        }
        reader.Close();
        connection.Close();
        return allProducts;
    }
    public List<InventoryItem> GetAllInventoryItems()
    {
        List<InventoryItem> allInventoryItems = new List<InventoryItem>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM InventoryItems", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            int storeId = reader.GetInt32(1);
            int productId = reader.GetInt32(2);
            int quantity = reader.GetInt32(3);
            InventoryItem inventoryItem = new InventoryItem{
                Id = id,
                StoreId = storeId,
                ProductId = productId,
                Quantity = quantity
            };
            allInventoryItems.Add(inventoryItem);
        }
        reader.Close();
        connection.Close();
        return allInventoryItems;
    }
    public List<OrderItem> GetAllOrderItems()
    {
        List<OrderItem> allOrderItems = new List<OrderItem>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM OrderItems", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            int orderId = reader.GetInt32(1);
            int productId = reader.GetInt32(2);
            int quantity = reader.GetInt32(3);
            OrderItem orderItem = new OrderItem{
                Id = id,
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity
            };
            allOrderItems.Add(orderItem);
        }
        reader.Close();
        connection.Close();
        return allOrderItems;   
    }
    public List<Order> GetAllOrders()
    {
        List<Order> allOrders = new List<Order>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            int customerId = reader.GetInt32(1);
            int storeId = reader.GetInt32(2);
            DateTime datePlaced = reader.GetDateTime(3);
            Order order = new Order{
                Id = id,
                CustomerId = customerId,
                StoreId = storeId,
                DatePlaced = datePlaced
            };
            allOrders.Add(order);
        }
        reader.Close();
        connection.Close();
        return allOrders;
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
    public void PurchaseItem(int customerId, int storeId, int inventoryItemId, int quantity)
    {
/*        // check if there is an 

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
*/
    }
}