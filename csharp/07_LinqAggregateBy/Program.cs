var employees = new List<Employee>
{
    new("Alice", "HR", 60000),
    new("Bob", "IT", 80000),
    new("Charlie", "HR", 65000),
    new("David", "IT", 85000),
    new("Eve", "Marketing", 70000)
};

var totalSalariesByDept = employees.AggregateBy(
    keySelector: e => e.Department,
    seed: 0m,
    func: (totalSalary, employee) => totalSalary + employee.Salary
);

foreach (var (department, totalSalary) in totalSalariesByDept)
{
    Console.WriteLine($"Department: {department}, Total Salary: {totalSalary:C}");
}

/*
    Department: HR, Total Salary: CHF 125'000.00
    Department: IT, Total Salary: CHF 165'000.00
    Department: Marketing, Total Salary: CHF 70'000.00
*/

public record Employee(string Name, string Department, decimal Salary);
