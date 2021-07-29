using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Contracts
{
    public interface ITaskRecordRepository
    {
        Task<IEnumerable<TaskRecord>> GetTaskRecords();
        
        void AddTaskRecord(TaskRecord taskRecord);
        
        Task SaveChanges();
        
        Task<TaskRecord> GetTaskRecordById(int id);
        
        void UpdateTaskRecord(TaskRecord taskRecord);
        
        void RemoveTaskRecord(TaskRecord task);
    }
}