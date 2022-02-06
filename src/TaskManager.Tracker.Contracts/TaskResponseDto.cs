using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Tracker.Contracts;

public sealed class TaskResponseDto<T>
{
    public bool Success => Errors == null || !Errors.Any();

    public T Payload { get; init; }

    public IEnumerable<string> Errors { get; init; }
}
