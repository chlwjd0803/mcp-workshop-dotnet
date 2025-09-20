using System;
using System.Threading.Tasks;
using MyMonkeyApp.Helpers;

namespace MyMonkeyApp;

class Program
{
    static async Task Main(string[] args)
    {
        AsciiArtHelper.DisplayWelcomeBanner();

        while (true)
        {
            DisplayHelper.DisplayMenu();
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\n❌ Please enter a valid number between 1 and 4.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1: // List all monkeys
                        var allMonkeys = await MonkeyHelper.GetAllMonkeysAsync();
                        DisplayHelper.DisplayMonkeyList(allMonkeys);
                        break;

                    case 2: // Get details for a specific monkey
                        Console.Write("\nEnter the name of the monkey: ");
                        var name = Console.ReadLine();
                        var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name);
                        
                        if (monkey == null)
                            Console.WriteLine("\n❌ Monkey not found! Please check the name and try again.");
                        else
                            DisplayHelper.DisplayMonkeyDetails(monkey);
                        break;

                    case 3: // Get a random monkey
                        var randomMonkey = await MonkeyHelper.GetRandomMonkeyAsync();
                        if (randomMonkey == null)
                            Console.WriteLine("\n❌ No monkeys available!");
                        else
                        {
                            Console.WriteLine("\n🎲 Random monkey selected!");
                            Console.WriteLine(AsciiArtHelper.GetRandomMonkeyArt());
                            DisplayHelper.DisplayMonkeyDetails(randomMonkey, true);
                        }
                        break;

                    case 4: // Exit app
                        Console.WriteLine("\n👋 Thank you for using the Monkey App! Goodbye!");
                        return;

                    default:
                        Console.WriteLine("\n❌ Please enter a number between 1 and 4.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            AsciiArtHelper.DisplayWelcomeBanner();
        }
    }
}
