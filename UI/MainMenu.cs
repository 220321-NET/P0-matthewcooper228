using Models;
using System.ComponentModel.DataAnnotations;
using BL;
using DL;

namespace UI;
internal class MainMenu
{
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
                    Console.WriteLine("Never give up, never surrender.");
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
        List<Customer> allCustomers = _bl.GetAllExistingCustomers();
        foreach(Customer customerToCheck in allCustomers)
        {
            if ( customerToCheck.UserName == userName )
            {
                customerExists = true;
                Console.WriteLine("Welcome back, " + userName + ".");
                Console.WriteLine("Please make a selection:");
                Console.WriteLine("");

            }
        }
        if(!customerExists)
        {
            Console.WriteLine(userName + " is not an existing customer.");
        }

    }
    private void ProceedAsNewCustomer()
    {

    }
    private void ProceedAsEmployee()
    {

    }
}