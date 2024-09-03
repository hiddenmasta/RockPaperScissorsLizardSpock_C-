using System.Text;

/// <summary>
/// Represents a player in a console game
/// </summary>
public interface IPlayer
{
    /// <summary>
    /// The summary of the game from this player's point of view
    /// </summary>
    StringBuilder GameSummary { get; }

    /// <summary>
    /// Assigned player number
    /// </summary>
    int Number { get; }
}
