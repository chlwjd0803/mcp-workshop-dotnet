using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Static helper class for managing and accessing monkey data from the MCP server.
/// </summary>
public static class MonkeyHelper
{
    // Cache for storing monkey data
    private static List<Monkey>? _monkeys;
    
    // Dictionary to track how many times each monkey has been randomly selected
    private static readonly Dictionary<string, int> _accessCount = new();
    
    // Random number generator for selecting random monkeys
    private static readonly Random _random = new();

    /// <summary>
    /// Gets all available monkeys from the MCP server.
    /// Results are cached after the first call.
    /// </summary>
    /// <returns>A list of all monkeys.</returns>
    public static async Task<IEnumerable<Monkey>> GetAllMonkeysAsync()
    {
        if (_monkeys != null)
            return _monkeys;

        try
        {
            var monkeys = await McpMonkeymcp.GetMonkeysAsync();
            _monkeys = monkeys.Select(m => new Monkey
            {
                Name = m.Name,
                Location = m.Location,
                Details = m.Details,
                Image = m.Image,
                Population = m.Population,
                Latitude = m.Latitude,
                Longitude = m.Longitude
            }).ToList();
            return _monkeys;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching monkey data: {ex.Message}");
            return Enumerable.Empty<Monkey>();
        }
    }

    /// <summary>
    /// Gets a random monkey from the available monkeys and tracks the access count.
    /// </summary>
    /// <returns>A randomly selected monkey, or null if no monkeys are available.</returns>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var monkeys = await GetAllMonkeysAsync();
        var monkeyList = monkeys.ToList();
        
        if (!monkeyList.Any())
            return null;

        var randomIndex = _random.Next(monkeyList.Count);
        var selectedMonkey = monkeyList[randomIndex];

        // Track access count
        if (!_accessCount.ContainsKey(selectedMonkey.Name))
            _accessCount[selectedMonkey.Name] = 0;
        _accessCount[selectedMonkey.Name]++;

        return selectedMonkey;
    }

    /// <summary>
    /// Finds a monkey by their name.
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey with the specified name, or null if not found.</returns>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        var monkeys = await GetAllMonkeysAsync();
        return monkeys.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a monkey has been randomly selected.
    /// </summary>
    /// <param name="monkeyName">The name of the monkey to check.</param>
    /// <returns>The number of times the monkey has been randomly selected.</returns>
    public static int GetAccessCount(string monkeyName)
    {
        return _accessCount.TryGetValue(monkeyName, out var count) ? count : 0;
    }
}