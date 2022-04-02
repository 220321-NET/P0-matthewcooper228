// user interface namespace
namespace UI;
// existing customer menu
public static class ExistingCustomerMenu {
    // method to start existing customer menu
    public static void Start()
    {
        // keep track if existing customer wants to go back
        bool exit = false;
        do {
        // check existing users credentials
        Console.WriteLine("");
        Console.WriteLine("What is your username?");
        string? userName = Console.ReadLine();
        exit = true;
        } while (!exit);
    }
}