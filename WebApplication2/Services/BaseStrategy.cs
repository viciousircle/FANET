using System;

namespace WebApplication2.Services;

public abstract class BaseStrategy
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UAVCount { get; set; }
    public TimeSpan MaxDuration { get; set; }
    public double MaxRange { get; set; }
    public double TransmissionSpeed { get; set; }

    public abstract void Execute();
}

