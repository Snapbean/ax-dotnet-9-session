// required a combination of GroupBy and Count before .NET 9

var employees = new List<Employee>
{
    new("Alice", "HR"),
    new("Bob", "IT"),
    new("Charlie", "HR"),
    new("David", "IT"),
    new("Eve", "Marketing")
};

var departmentCounts = employees.CountBy(e => e.Department);
foreach (var (department, count) in departmentCounts)
{
    Console.WriteLine($"Department: {department}, Employee Count: {count}");
}

/*
    Department: HR, Employee Count: 2
    Department: IT, Employee Count: 2
    Department: Marketing, Employee Count: 1
*/

public record Employee(string Name, string Department);
