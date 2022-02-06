using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Contracts;

public interface ITaskRecordRepository
{
    Task<IEnumerable<TaskRecord>> GetTaskRecords();

    void AddTaskRecord(TaskRecord taskRecord);

    Task<TaskRecord> GetTaskRecordById(int id);

    void RemoveTaskRecord(TaskRecord task);
}
