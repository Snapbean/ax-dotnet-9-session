var computationTasks = Enumerable.Range(1, 5).Select(async id =>
{
    var delay = Random.Shared.Next(500, 3000); 
    await Task.Delay(delay); // Simulate work
    return new ComputationResult(id, delay, id * 2);
});

var tasksWhenAll = computationTasks.ToList();
var allResults = await Task.WhenAll(tasksWhenAll);
foreach (var result in allResults)
{
    Console.WriteLine($"Computation {result.Id} finished in {result.Delay} ms. Result: {result.Value}");
}
/*
    Computation 1 finished in 2753 ms. Result: 2
    Computation 2 finished in 1127 ms. Result: 4
    Computation 3 finished in 2201 ms. Result: 6
    Computation 4 finished in 2720 ms. Result: 8
    Computation 5 finished in 2184 ms. Result: 10
 */

var tasksWhenEach = computationTasks.ToList();
await foreach (var task in Task.WhenEach(tasksWhenEach))
{
    var result = await task;
    Console.WriteLine($"Computation {result.Id} finished in {result.Delay} ms. Result: {result.Value}");
}
/*
    Computation 4 finished in 528 ms. Result: 8
    Computation 3 finished in 839 ms. Result: 6
    Computation 1 finished in 2026 ms. Result: 2
    Computation 2 finished in 2855 ms. Result: 4
    Computation 5 finished in 2984 ms. Result: 10
 */

record ComputationResult(int Id, int Delay, int Value);
