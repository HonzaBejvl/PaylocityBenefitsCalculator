using System;

namespace Api.Temporal;

public interface IClock
{
    /// <summary>
    /// Returns current date and time.
    /// </summary>
    DateTime UtcNow { get; }
}