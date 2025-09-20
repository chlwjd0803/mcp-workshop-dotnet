using System;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Provides ASCII art for the monkey application.
/// </summary>
public static class AsciiArtHelper
{
    private static readonly Random _random = new();
    
    private static readonly string[] _monkeyArt = new[]
    {
        @"  __,,__
  .--.    .--.
 ( (  )  (  ) )
  \`-'    `-'/
   .--|__|--.
  /  |  |  |
 |   \  /   |
 \    \/    /
  `-.    .-'
     |  |
     |  |",
        @"   _
  (((,
 '-..-'
   oo      
  C  )  
 ( _) ",
        @"  .-=-.
 (     )
  `>-<´
  (  )
   )/
  ( \
   ´",
        @"  ,---.
 /    _)
|    (
 \   )
  `--'
  /|\
  \|/",
    };

    /// <summary>
    /// Gets a random monkey ASCII art pattern.
    /// </summary>
    /// <returns>A string containing random ASCII art of a monkey.</returns>
    public static string GetRandomMonkeyArt()
    {
        var index = _random.Next(_monkeyArt.Length);
        return _monkeyArt[index];
    }

    /// <summary>
    /// Displays the welcome banner for the application.
    /// </summary>
    public static void DisplayWelcomeBanner()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("🐒 Welcome to the Monkey App! 🐒");
        Console.WriteLine("=================================\n");
        Console.WriteLine(GetRandomMonkeyArt());
        Console.WriteLine();
    }
}