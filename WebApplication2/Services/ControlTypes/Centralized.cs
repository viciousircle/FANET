using System;

namespace WebApplication2.Services.ControlTypes;

public class Centralized : BaseStrategy
{
    public override void Execute()
    {
        Console.WriteLine("Executing centralized...");
    }
}
