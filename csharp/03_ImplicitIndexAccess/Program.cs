// in versions before C# 13, the ^ operator can't be used in an object initializer

var scoreboard = new Scoreboard
{
    Scores =
    {
        [^1] = 100, // Last element
        [^2] = 200, // Second-to-last element
        [^3] = 300, // Third-to-last element
        [^4] = 400, // Fourth-to-last element
        [^5] = 500 // Fifth-to-last element
    }
};

public class Scoreboard
{
    public int[] Scores { get; } = new int[5];
}