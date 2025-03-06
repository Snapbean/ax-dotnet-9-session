Console.WriteLine();

public class OldLock
{
    private readonly object _myLock = new();

    public void MyMethod()
    {
        lock (_myLock)
        {
            // Critical section
        }
    }
}

// Lock uses a better thread synchronization api (e.g. better performance)
public class NewLock
{
    private readonly Lock _myLock = new();

    public void MyMethod()
    {
        lock (_myLock)
        {
            // Critical section
        }
    }
}
