// limited to array types in .NET 8
var numbersArray = new[] {1, 2, 3, 4};
ShowNumbersArray(numbersArray);
ShowNumbersArray(1, 2, 3, 4);

void ShowNumbersArray(params int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write(number);
        Console.Write(" ");
    }
    Console.WriteLine();
}

// any collection type in .NET 9
var numbersList = new List<int> { 1, 2, 3, 4 };
ShowNumbersEnumerable(numbersList);
ShowNumbersEnumerable(1, 2, 3, 4);
ShowNumbersList(numbersList);
ShowNumbersList(1, 2, 3, 4);

void ShowNumbersEnumerable(params IEnumerable<int> numbers)
{
    foreach (var number in numbers)
    {
        Console.Write(number);
        Console.Write(" ");
    }
    Console.WriteLine();
}

void ShowNumbersList(params List<int> numbers)
{
    foreach (var number in numbers)
    {
        Console.Write(number);
        Console.Write(" ");
    }
    Console.WriteLine();
}

var numbersReadOnlySpan = new ReadOnlySpan<int>([1, 2, 3, 4]);
ShowNumbersReadOnlySpan(numbersReadOnlySpan);
ShowNumbersReadOnlySpan(1, 2, 3, 4);

void ShowNumbersReadOnlySpan(params ReadOnlySpan<int> numbers)
{
    foreach (var number in numbers)
    {
        Console.Write(number);
        Console.Write(" ");
    }
    Console.WriteLine();
}
