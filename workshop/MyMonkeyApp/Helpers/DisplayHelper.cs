using System;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Helper class for formatting and displaying monkey information.
/// </summary>
public static class DisplayHelper
{
    /// <summary>
    /// Displays detailed information about a monkey.
    /// </summary>
    /// <param name="monkey">The monkey to display information for.</param>
    /// <param name="showAccessCount">Whether to show the random access count.</param>
    public static void DisplayMonkeyDetails(Monkey monkey, bool showAccessCount = false)
    {
        Console.WriteLine("\n📋 Monkey Details:");
        Console.WriteLine("==================");
        Console.WriteLine($"🐒 Name: {monkey.Name}");
        Console.WriteLine($"📍 Location: {monkey.Location}");
        Console.WriteLine($"ℹ️  Details: {monkey.Details}");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        Console.WriteLine($"📌 Coordinates: ({monkey.Latitude:F6}, {monkey.Longitude:F6})");
        
        if (showAccessCount)
        {
            var accessCount = MonkeyHelper.GetAccessCount(monkey.Name);
            Console.WriteLine($"🎲 Times Randomly Selected: {accessCount}");
        }
        
        Console.WriteLine("==================\n");
    }

    /// <summary>
    /// Displays a list of all monkeys in a condensed format.
    /// </summary>
    /// <param name="monkeys">The collection of monkeys to display.</param>
    public static void DisplayMonkeyList(IEnumerable<Monkey> monkeys)
    {
        Console.WriteLine("\n📋 Monkey List:");
        Console.WriteLine("==================");
        
        foreach (var monkey in monkeys)
        {
            Console.WriteLine($"🐒 {monkey.Name} - 📍 {monkey.Location} (Population: {monkey.Population:N0})");
        }
        
        Console.WriteLine("==================\n");
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    public static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1. List all monkeys");
        Console.WriteLine("2. Get details for a specific monkey");
        Console.WriteLine("3. Get a random monkey");
        Console.WriteLine("4. Exit app");
        Console.Write("\nEnter your choice (1-4): ");
    }
}