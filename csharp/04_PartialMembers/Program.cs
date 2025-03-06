var person = new Person { Name = "Foo" };

public partial class Person
{
    // declaration
    public partial string Name { get; set; }
}

public partial class Person
{
    // implementation
    private string _name;
    public partial string Name
    {
        get => _name;
        set => _name = value;
    }
}

// restriction: no auto-property for implementing partial members:
// public partial class Member
// {
//     public partial string FirstName { get; set; }
//     public partial string LastName { get; set; } = "Unknown"    
// }
