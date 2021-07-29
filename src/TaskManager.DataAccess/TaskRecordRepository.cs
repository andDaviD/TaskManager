using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Contracts;

namespace TaskManager.DataAccess
{
    internal sealed class TaskRecordRepository : ITaskRecordRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskRecordRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<TaskRecord>> GetTaskRecords()
        {
            return await _dbContext.TaskRecords.ToListAsync();
        }

        public void AddTaskRecord(TaskRecord taskRecord)
        {
            _dbContext.TaskRecords.Add(taskRecord);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TaskRecord> GetTaskRecordById(int id)
        {
            return await _dbContext.TaskRecords.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateTaskRecord(TaskRecord taskRecord)
        {
            _dbContext.TaskRecords.Update(taskRecord);
        }

        public void RemoveTaskRecord(TaskRecord task)
        {
            _dbContext.TaskRecords.Remove(task);
        }
    }
}