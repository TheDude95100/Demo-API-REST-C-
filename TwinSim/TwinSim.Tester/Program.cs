using System;
using TwinSim.Domain.Models;

class Program
{
    static void Main()
    {

        var obj = new TwinObject
        {
            Name = "TestBot",
            Position = new Position(1f, 2f, 3f),
            Status = Status.Active
        };

        Console.WriteLine($"Name: {obj.Name}, Status: {obj.Status}, ID: {obj.Id}");
    }
}