using System.Threading.Tasks;

namespace TaskManager.Tracker.Contracts
{
    public interface ITaskService
    {
        public Task<TaskResponseDto<GetTaskResponseDto>> GetTasks();
        
        public Task<TaskResponseDto<CreateTaskResponseDto>> CreateTask(CreateTaskRequestDto requestDto);
        
        public Task<TaskResponseDto<CompleteTaskResponseDto>> CompleteTask(CompleteTaskRequestDto requestDto);
        
        public Task<TaskResponseDto<RemoveTaskResponseDto>> RemoveTask(RemoveTaskRequestDto requestDto);
    }
}