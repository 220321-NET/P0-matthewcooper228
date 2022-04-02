// user interface namespace
namespace UI;
// customer menu
public static class CustomerMenu {
    // method to start customer menu
    public static void Start()
    {
        // keep track if customer wants to go back
        bool exit = false;
        do {
        // provide customer with options
        Console.WriteLine("");
        Console.WriteLine("Please make a selection:");
        Console.WriteLine("[1] I am an existing customer");
        Console.WriteLine("[2] I am a new customer");
        Console.WriteLine("[3] I want to go back.");
        Console.WriteLine("[X] I want to exit program.");
        // get customers selection
        string? input = Console.ReadLine();
        // take action based on customers input
        switch(input)
        {
            // go to existing customer menu
            case "1":
                ExistingCustomerMenu.Start();
            break;
            // go to new customer menu
            case "2":
                NewCustomerMenu.Start();
            break;
            // go back to previous menu
            case "3":
                exit = true;
            break;
            case "x":
            case "X":
                MainMenu.Exit = true;
                exit = true;
                Console.WriteLine("");
                Console.WriteLine("Goodbye");
            break;
        }
        } while (!exit);
    }
}