using System;

namespace TaskManager.DataAccess.Contracts;

public sealed class TaskRecord
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; }

    public string Title { get; set; }
}
