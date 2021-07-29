using System;

namespace TaskManager.Web.Models
{
    public sealed record TaskRecord(string Title, string Description, DateTime Date, bool IsCompleted);
}