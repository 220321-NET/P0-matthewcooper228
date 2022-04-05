using Models;
using System.ComponentModel.DataAnnotations;
using BL;
using System.Text.RegularExpressions;

namespace UI;
internal class MainMenu
{
    public int LoggedInCustomerId = 0;
    public string LoggedInCustomerUserName = "";
    public int LoggedInEmployeeId = 0;
    public bool IsCustomer = false;
    public bool IsEmployee = false;
    public int CurrentStoreId = 0;
    public string CurrentStoreAddress = "";

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
                    LoggedInCustomerUserName = userName;
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
            LoggedInCustomerUserName = newUserName;
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

    }
}