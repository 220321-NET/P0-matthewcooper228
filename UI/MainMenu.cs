using Models;
using System.ComponentModel.DataAnnotations;
using BL;
using System.Text.RegularExpressions;

namespace UI;
internal class MainMenu
{
    public int CurrentCustomerId = 0;
    public string CurrentCustomerUserName = "";
    public int CurrentEmployeeId = 0;
    public bool IsCustomer = false;
    public bool IsEmployee = false;
    public int CurrentStoreId = 0;
    public string CurrentStoreAddress = "";
    public int CurrentInventoryItemId = 0;
    public int CurrentInventoryItemQuantity = 0;
    public int CurrentProductId = 0;
    public int CurrentOrderId = 0;

    private readonly ISLBL _bl;
    // dependency injection
    public MainMenu(ISLBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {      
        bool exit = false;
        Console.WriteLine("TECH VALUE ELECTRONICS SUPERSTORE");
        Console.WriteLine("\"By Grabthar's hammer... what a savings.\"");
        do
        {
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("[1] I am a customer.");
            Console.WriteLine("[2] I am an employee.");
            Console.WriteLine("[X] I want to exit program.");
            Console.Write("Please type a number or X and then press enter: ");
            string? input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    ProceedAsCustomer();
                    break;
                case "2":
                    ProceedAsEmployee();
                    break;
                case "x":
                case "X":
                    Console.WriteLine("\"Never give up, never surrender.\"");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    break;
            }
        }
        while (!exit);
    }
    // helper methods
    private void ProceedAsCustomer()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("[1] I am an existing customer.");
            Console.WriteLine("[2] I am a new customer.");
            Console.WriteLine("[X] I want to go back.");
            Console.Write("Please type a number or X and then press enter: ");
            string? input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    ProceedAsExistingCustomer();
                    break;
                case "2":
                    ProceedAsNewCustomer();
                    break;
                case "x":
                case "X":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    break;
            }
        }
        while (!exit);
    }
    private void ProceedAsExistingCustomer()
    {
        Console.Write("Please enter your username: ");
        bool customerExists = false;
        string? userName = Console.ReadLine();
        List<Customer> allCustomers = _bl.GetAllCustomers();
        foreach(Customer customerToCheck in allCustomers)
        {
            if ( customerToCheck.UserName == userName )
            {
                customerExists = true;
                if(userName != null)
                {
                    CurrentCustomerUserName = userName;
                    CurrentCustomerId = customerToCheck.Id;
                    IsCustomer = true;
                    IsEmployee = false;
                    Console.WriteLine("Welcome back, " + userName + ".");
                    bool exit = false;
                    do
                    {
                        Console.WriteLine("Please make a selection:");
                        Console.WriteLine("[1] I want to shop.");
                        Console.WriteLine("[2] I want to see my order history.");
                        Console.WriteLine("[X] I want to go back.");
                        Console.Write("Please type a number or X and then press enter: ");
                        string? input = Console.ReadLine();
                        switch(input)
                        {
                            case "1":
                                ProceedToChooseStoreAsCustomer();
                                break;
                            case "2":
                                ProceedToViewOrderHistoryAsCutomer();
                                break;
                            case "x":
                            case "X":
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input, try again.");
                                break;
                        }
                    } while (!exit);
                }
            }
        }
        if(!customerExists)
        {
            Console.WriteLine(userName + " is not an existing customer.");

        }

    }
    private void ProceedAsNewCustomer()
    {
        EnterUserName:
        Console.Write("Type your desired username then press enter: ");
        string? newUserName = Console.ReadLine();
        string pattern = @"^[a-zA-z]+$";
        if (newUserName == null)
        {
            Console.WriteLine("Username can only contain only contain letters and must be one or more letters long.");
            goto EnterUserName;
        }
        else if (Regex.Match(newUserName, pattern).Success)
        {
            Customer newCustomer = new Customer();
            newCustomer.UserName = newUserName!;
            _bl.AddCustomer(newCustomer);
            List<Customer> allCustomers = _bl.GetAllCustomers();
            foreach(Customer customer in allCustomers)
            {
                if(customer.UserName == newCustomer.UserName)
                {
                    CurrentCustomerId = customer.Id;
                    CurrentCustomerUserName = customer.UserName;
                }
            }
            IsCustomer = true;
            IsEmployee = false;

            Console.WriteLine("You have created an account as " + newUserName + ". Please login as an existing user.");

        } 
        else
        {
            Console.WriteLine("Username can only contain only contain letters and must be one or more letters long.");
            goto EnterUserName;
        } 
        
    }
    private void ProceedAsEmployee()
    {

    }
    private void ProceedToChooseStoreAsCustomer()
    {
        bool exit = false;
        do
        {
            List<Store> allStores = _bl.GetAllStores();
            Console.WriteLine("Please make a selection:");
            for(int i = 0; i < allStores.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] I want to shop at " + allStores[i].Address + ".");
            }
            Console.WriteLine("[X] I want to go back.");
            Console.Write("Please type a number or X and then press enter: ");
            string? input = Console.ReadLine();
            bool inputIsValid = false;
            for (int i = 0; i < allStores.Count; i++)
            {
                if (input == (i + 1).ToString())
                {
                    CurrentStoreAddress = allStores[i].Address!;
                    CurrentStoreId = allStores[i].Id;
                    inputIsValid = true;
                    ProceedToStoreAsCustomer();
                }
            }
            if (input == "x" || input == "X")
            {
                inputIsValid = true;
                exit = true;
            }
            else if(!inputIsValid)
            {
                Console.WriteLine("Invalid input, try again.");
            }
        } while (!exit);
    }
    private void ProceedToViewOrderHistoryAsCutomer() {

    }
    private void ProceedToStoreAsCustomer()
    {
        Console.WriteLine("You are shopping at " + CurrentStoreAddress + ".");
        bool exit = false;
        do
        {
            Console.WriteLine("Here is what we have:");
            List<InventoryItem> inventoryItems = _bl.GetAllInventoryItems();
            List<Product> products = _bl.GetAllProducts();
            for( int i = 0; i < inventoryItems.Count; i++ )
            {
                if(inventoryItems[i].StoreId == CurrentStoreId)
                {
                    foreach (Product product in products)
                    {
                        if (product.Id == inventoryItems[i].ProductId)
                        {
                            Console.WriteLine("- " + product.Name + " (there are " + inventoryItems[i].Quantity + " available)");
                        }
                    }
                }
            }
            Console.WriteLine("[N] I want to start an order");
            Console.WriteLine("[X] I want to go back.");
            Console.Write("Please type N or X and then press enter: ");
            string? input = Console.ReadLine();
            if (input == "x" || input == "X")
            {
                exit = true;
            } else if (input == "N" || input == "n")
            {
                Order newOrder = new Order();
                newOrder.CustomerId = CurrentCustomerId;
                newOrder.StoreId = CurrentStoreId;
                newOrder.DatePlaced = DateTime.Now;
                _bl.AddNewOrder(newOrder);
                List<Order> orders = _bl.GetAllOrders();
                for(int i = 0; i < orders.Count; i++ )
                {
                    if(orders[i].DatePlaced.ToString() == newOrder.DatePlaced.ToString())
                    {
                        CurrentOrderId = orders[i].Id;
                    }
                }
                ProceedToPurchaseAsACustomer();
            }
            else {
                Console.WriteLine("Invalid input, try again.");
            }
        } while (!exit);            
    }
    private void ProceedToPurchaseAsACustomer()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("What would you like to add to your oder:");
            List<InventoryItem> inventoryItems = _bl.GetAllInventoryItems();
            List<Product> products = _bl.GetAllProducts();
            for( int i = 0; i < inventoryItems.Count; i++ )
            {
                if(inventoryItems[i].StoreId == CurrentStoreId)
                {
                    foreach (Product product in products)
                    {
                        if (product.Id == inventoryItems[i].ProductId)
                        {
                            Console.WriteLine("[" + (i + 1) + "]" + " I want to add " + product.Name + "s to my order (there are " + inventoryItems[i].Quantity + " available).");
                        }
                    }
                }
            }
            Console.WriteLine("[X] I want to complete my order and go back.");
            Console.Write("Please type a number or X and then press enter: ");
            string? input = Console.ReadLine();
            if (input == "x" || input == "X")
            {
                exit = true;
            }
            for( int i = 0; i < inventoryItems.Count; i++ )
            {
                if(inventoryItems[i].StoreId == CurrentStoreId)
                {
                    foreach (Product product in products)
                    {
                        if (product.Id == inventoryItems[i].ProductId)
                        {
                            if (input == (i + 1).ToString())
                            {
                                CurrentInventoryItemId = inventoryItems[i].Id;
                                CurrentProductId = product.Id;
                                ProceedToAddItemAsACustomer();
                            }
                        }
                    }
                }
            }
        } while (!exit);            
    }
    public void ProceedToAddItemAsACustomer()
    {
        List<Product> products = _bl.GetAllProducts();
        List<InventoryItem> inventoryItems = _bl.GetAllInventoryItems();
        for(int i = 0; i < inventoryItems.Count; i++)
        {
            for(int j = 0; j < products.Count; j++)
            {
                if (products[j].Id == CurrentProductId && inventoryItems[i].ProductId == CurrentProductId && inventoryItems[i].StoreId == CurrentStoreId)
                {
                    bool exit = false;
                    do
                    {
                        Console.WriteLine("How many " + products[j].Name + "s do you want (there are " + inventoryItems[i].Quantity + ")?");
                        Console.Write("Enter a number between 0 and " + inventoryItems[i].Quantity + ": ");
                        string? input = Console.ReadLine();
                        if(input == null)
                        {
                            Console.WriteLine("Invalid input, try again.");
                        }
                        else if(Regex.IsMatch(input, @"^[0-9]+$") && 0 <= Int32.Parse(input) && Int32.Parse(input) <= inventoryItems[i].Quantity)
                        {
                            OrderItem newOrderItem = new OrderItem();
                            newOrderItem.OrderId = CurrentOrderId;
                            newOrderItem.ProductId = CurrentProductId;
                            newOrderItem.Quantity = Int32.Parse(input);
                            _bl.AddNewOrderItem(newOrderItem);
                            Console.WriteLine(input + " " + products[j].Name + " have been to your order." );
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again.");
                        }
                    }
                    while(!exit);
                }
            }
        }
    }
}