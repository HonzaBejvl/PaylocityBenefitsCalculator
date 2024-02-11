using System;

namespace Api.Temporal;

/// <summary>
/// <see cref="IClock"/> that uses system time.
/// </summary>
public class SystemClock : IClock
{
    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;
}
