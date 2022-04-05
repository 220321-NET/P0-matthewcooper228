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
            Console.WriteLine("[x] I want to exit program.");
            Console.Write("Please type a number or x and then press enter: ");
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
            Console.WriteLine("[x] I want to go back.");
            Console.Write("Please type a number or x and then press enter: ");
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
                        Console.WriteLine("[x] I want to go back.");
                        Console.Write("Please type a number or x and then press enter: ");
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

            Console.WriteLine("You have created an account. Welcome, " + newUserName + ".");

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
            Console.WriteLine("[x] I want to go back.");
            Console.Write("Please type a number or x and then press enter: ");
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
            Console.WriteLine("Please make a selection:");
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
            Console.WriteLine("[x] I am finished with my order and want to go back.");
            Console.Write("Please type a number or x and then press enter: ");
            string? input = Console.ReadLine();
            bool inputIsValid = false;
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (input == (i + 1).ToString())
                {
                    inputIsValid = true;
                    CurrentInventoryItemId = inventoryItems[i].Id;
                    foreach (Product product in products)
                    {
                        if (product.Id == inventoryItems[i].ProductId)
                        {
                            CurrentProductId = product.Id;
                        }
                    }
                    ProceedToAddInventoryItemToOrder();
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
    private void ProceedToAddInventoryItemToOrder()
    {
        ProceedToAddInventoryItemToOrder:
        List<Product> products = _bl.GetAllProducts();
        List<InventoryItem> inventoryItems = _bl.GetAllInventoryItems();
        foreach(InventoryItem inventoryItem in inventoryItems)
        {
            foreach (Product product in products)
            {
                if (product.Id == CurrentProductId && inventoryItem.Id == CurrentInventoryItemId)
                {
                    CurrentInventoryItemQuantity = inventoryItem.Quantity;
                    Console.WriteLine("How many " + product.Name + "s do you want to add to your order (there are " + inventoryItem.Quantity + " available)?");
                    Console.Write("Please enter a number between 0 and " + inventoryItem.Quantity + ": ");
                }
            }
        }
        string? input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("Invalid input, try again.");
            goto ProceedToAddInventoryItemToOrder;
        }
        string pattern = @"^[0-9]+$";
        if (!Regex.Match(input, pattern).Success)
        {
            Console.WriteLine("Invalid input, try again.");
            goto ProceedToAddInventoryItemToOrder;
        }
        int quantityPurchasing = Int32.Parse(input);

    }

}