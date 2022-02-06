using System;

namespace TaskManager.Tracker.Contracts;

public sealed record CreateTaskRequestDto(string Title, string Description, DateTime DateTime, bool IsCompleted);
