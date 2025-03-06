// Randomly generated (version 4)
var guids = new List<Guid>
{
    Guid.NewGuid(),
    Guid.NewGuid(),
    Guid.NewGuid()
};

// Timestamp-based
var guid7s = new List<Guid>
{
    Guid.CreateVersion7(),
    Guid.CreateVersion7(),
    Guid.CreateVersion7()
};

foreach (var g in guids.OrderBy(g => g)) Console.WriteLine(g);
/*
   ae63f437-4db4-45fc-bf15-0909904c700c
   b19807c8-cca3-4fcc-94cd-4015afd44c6e
   d6f23dfd-b5d7-4e82-a0a6-bf4759ed1e0e  
*/

foreach (var g in guid7s.OrderBy(g => g)) Console.WriteLine(g);
/*
   0194df4c-a84d-704f-9a56-bcbcdf7e7ceb
   0194df4c-a84d-7867-82b9-f76c73405475
   0194df4c-a84d-79c8-83c4-ca3e6570ff01
*/

// Work with databases or need a more structured, sequential GUID format (e.g. logging) -> Guid7
// Require true randomness for security-sensitive scenarios -> Guid (v4)