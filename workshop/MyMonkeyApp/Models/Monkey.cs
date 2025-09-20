using System;

namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey entity with its characteristics and location information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the geographical location where the monkey can be found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets detailed information about the monkey species or individual.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL to the monkey's image.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of the monkey species.
    /// For individual monkeys, this value is typically 1.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets the latitude of the monkey's primary habitat or location.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude of the monkey's primary habitat or location.
    /// </summary>
    public double Longitude { get; set; }
}