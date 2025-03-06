using System.Runtime.CompilerServices;

Numbers.Write(1, 2, 3, 4);

public static class Numbers
{
    [OverloadResolutionPriority(1)]
    public static void Write(params int[] numbers)
    {
        foreach (var number in numbers)
        {
            Console.Write(number);
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    public static void Write(params Span<int> numbers)
    {
        foreach (var number in numbers)
        {
            Console.Write(number);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}