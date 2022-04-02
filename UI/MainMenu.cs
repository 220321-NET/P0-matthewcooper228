// user interface namespace
namespace UI;
// top level menu when program first runs
public class MainMenu
{
    public void Start()
    {
        bool exit = false;
            Console.WriteLine("");
            Console.WriteLine("Welcome to Tech Value Electronics Superstore.");
            Console.WriteLine("By Grabthar's hammer... what a savings.");
        do
        {
            // welcome user and find out if they are customer or employee

            Console.WriteLine("");
            Console.WriteLine("Please make a selection.");
            Console.WriteLine("[1] I am a customer");
            Console.WriteLine("[2] I am an employee");
            Console.WriteLine("[X] Exit");
            Console.WriteLine("");
            // get user's selection
            string? input = Console.ReadLine();
            // take action based on user's selection
            switch(input)
            {
                case "1":
                    // go to customer menu
                break;
                case "2":
                    // go to employee menu
                break;
                case "X":
                    // exit program
                    Console.WriteLine("");
                    Console.WriteLine("Goodbye");
                    exit = true;
                break;
                default:
                    // request valid input
                    Console.WriteLine("");
                    Console.WriteLine("invalid input, try again");
                break;
            }
        } while(!exit);
    }
}