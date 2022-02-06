using System;

namespace TaskManager.Tracker;

internal interface IDateTimeProvider
{
    DateTime Now { get; }
}
