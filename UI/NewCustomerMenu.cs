// user interface namespace
namespace UI;
// new customer menu
public static class NewCustomerMenu {
    // method to start new customer menu
    public static void Start()
    {
        // keep track if new customer wants to go back
        bool exit = false;
        do {
        // have new customer create a username
        Console.WriteLine("");
        Console.WriteLine("Create a username:");
        string? userName = Console.ReadLine();
        exit = true;
        } while (!exit);
    }
}