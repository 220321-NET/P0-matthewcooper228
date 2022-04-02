// user interface namespace
namespace UI;
// employee menu
public static class EmployeeMenu {
    // method to start employee menu
    public static void Start()
    {
        // keep track if employee wants to go back
        bool exit = false;
        do {
        // request emloyee's ID number 
        Console.WriteLine("");
        Console.WriteLine("What is your employee ID number?");
        // get customers selection
        string? EmployeeIDNumber = Console.ReadLine();
        // take action based on customers input
        exit = true;
        } while (!exit);
    }
}