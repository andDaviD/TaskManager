using System;

namespace TaskManager.Tracker.Contracts
{
    public sealed class TaskRecordDto
    {
        public DateTime Date { get; set; }
        
        public string Description { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public string Title { get; set; }
    }
}