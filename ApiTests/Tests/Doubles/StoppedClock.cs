using System;
using Api.Temporal;

namespace ApiTests.Tests.Doubles;

public class StoppedClock(DateTime utcNow) : IClock
{
    public DateTime UtcNow { get; } = utcNow;
}
