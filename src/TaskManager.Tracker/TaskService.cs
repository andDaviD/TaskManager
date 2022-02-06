using System.Linq;
using System.Threading.Tasks;
using TaskManager.DataAccess.Contracts;
using TaskManager.Tracker.Contracts;

namespace TaskManager.Tracker;

internal sealed class TaskService : ITaskService
{
    private readonly ITaskRecordRepository _taskRecordRepository;
    private readonly ITaskValidationService _taskValidationService;
    private readonly IUnitOfWork _unitOfWork;

    public TaskService(
        ITaskRecordRepository taskRecordRepository,
        ITaskValidationService taskValidationService,
        IUnitOfWork unitOfWork)
    {
        _taskRecordRepository = taskRecordRepository;
        _taskValidationService = taskValidationService;
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskResponseDto<GetTaskResponseDto>> GetTasks()
    {
        var taskRecordDtos = await _taskRecordRepository.GetTaskRecords();

        var taskRecords = taskRecordDtos.Select(dto =>
            new TaskRecordDto
            {
                Date = dto.Date,
                Description = dto.Description,
                Title = dto.Title,
                IsCompleted = dto.IsCompleted
            });

        return new TaskResponseDto<GetTaskResponseDto>
        {
            Payload = new GetTaskResponseDto(taskRecords)
        };
    }

    public async Task<TaskResponseDto<CreateTaskResponseDto>> CreateTask(CreateTaskRequestDto requestDto)
    {
        var validationErrors = _taskValidationService.ValidateCreateTaskRequest(requestDto);
        if (validationErrors.Count > 0)
        {
            return new TaskResponseDto<CreateTaskResponseDto>
            {
                Errors = validationErrors
            };
        }

        var taskRecord = new TaskRecord
        {
            Date = requestDto.DateTime,
            Description = requestDto.Description,
            Title = requestDto.Title,
            IsCompleted = requestDto.IsCompleted
        };

        _taskRecordRepository.AddTaskRecord(taskRecord);
        await _unitOfWork.SaveChanges();

        return new TaskResponseDto<CreateTaskResponseDto>
        {
            Payload = new CreateTaskResponseDto(taskRecord.Id)
        };
    }

    public async Task<TaskResponseDto<CompleteTaskResponseDto>> CompleteTask(CompleteTaskRequestDto requestDto)
    {
        var task = await _taskRecordRepository.GetTaskRecordById(requestDto.Id);
        if (task == null)
        {
            return new TaskResponseDto<CompleteTaskResponseDto>
            {
                Errors = new[] { "The task no longer exists." }
            };
        }

        task.IsCompleted = true;

        await _unitOfWork.SaveChanges();

        return new TaskResponseDto<CompleteTaskResponseDto>();
    }

    public async Task<TaskResponseDto<RemoveTaskResponseDto>> RemoveTask(RemoveTaskRequestDto requestDto)
    {
        var task = await _taskRecordRepository.GetTaskRecordById(requestDto.Id);
        if (task != null)
        {
            _taskRecordRepository.RemoveTaskRecord(task);
            await _unitOfWork.SaveChanges();
        }

        return new TaskResponseDto<RemoveTaskResponseDto>();
    }
}
