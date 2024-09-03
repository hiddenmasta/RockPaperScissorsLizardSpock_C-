/// <summary>
/// Represents a game which people can play through the console
/// </summary>
public interface IConsoleGame
{
    /// <summary>
    /// Verifies if the number of participants meets the requirements. Throws otherwise.
    /// </summary>
    /// <param name="numberOfParticipants"></param>
    /// <exception cref="ArgumentException">Throws when he number of participants isn't valid</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws an exception if the number of participants is out of the range</exception>
    void VerifyNumberOfParticipants(int numberOfParticipants);

    /// <summary>
    /// Creates a new player for the game from the console user input
    /// </summary>
    /// <exception cref="Exception">Throws when the reading or parsing fails</exception>
    void CreatesPlayerFromInput();

    /// <summary>
    /// Play the game
    /// </summary>
    /// <returns>Returns the winner of the game</returns>
    /// <exception cref="ArgumentException">Throws when he number of participants isn't valid</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws an exception if the number of participants is out of the range</exception>
    IPlayer Play();
}

