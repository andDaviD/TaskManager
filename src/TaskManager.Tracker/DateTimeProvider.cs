using System;

namespace TaskManager.Tracker;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}
