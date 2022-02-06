using AutoMapper;
using TaskManager.Tracker.Contracts;
using TaskManager.Web.Models;

namespace TaskManager.Web;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompleteTaskRequest, CompleteTaskRequestDto>();
        CreateMap<CompleteTaskResponseDto, CompleteTaskResponse>();
        CreateMap<CreateTaskRequest, CreateTaskRequestDto>();
        CreateMap<CreateTaskResponseDto, CreateTaskResponse>();
        CreateMap<GetTaskResponseDto, GetTaskResponse>();
        CreateMap<CloseTaskRequest, RemoveTaskRequestDto>();
        CreateMap<RemoveTaskRequestDto, CloseTaskRequest>();
        CreateMap<TaskRecordDto, TaskRecord>();
        CreateMap(typeof(TaskResponseDto<>), typeof(TaskResponse<>));
    }
}
