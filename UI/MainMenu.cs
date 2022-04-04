// user interface namespace
namespace UI;
// top level menu when program first runs
public static class MainMenu
{
    // method to start top level menu
    public static bool Exit = false;
    public static void Start()
    {
        // loop main menu until user wants to exit program
        do
        {
            // welcome user and find out if they are customer or employee
            Console.WriteLine("");
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("[1] I am a customer.");
            Console.WriteLine("[2] I am an employee.");
            Console.WriteLine("[X] I want to exit program.");
            Console.WriteLine("");
            // get user's selection
            string? input = Console.ReadLine();
            // take action based on user's selection
            switch(input)
            {
                case "1":
                    // go to customer menu
                    CustomerMenu.Start();
                break;
                case "2":
                    // go to employee menu
                    EmployeeMenu.Start();
                break;
                case "x":
                case "X":
                    // exit program
                    Console.WriteLine("");
                    Console.WriteLine("Goodbye");
                    // customer wants to exit
                    Exit = true;
                break;
                default:
                    // request valid input
                    Console.WriteLine("");
                    Console.WriteLine("invalid input, try again");
                break;
            }
        // keep looping main menu while customer does not want to exit
        } while(!Exit);
    }
}