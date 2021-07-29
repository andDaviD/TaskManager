using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Tracker.Contracts;
using TaskManager.Web.Models;

namespace TaskManager.Web.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public sealed class TaskManagerController : ControllerBase
    {
        private readonly IMapper _mapper;
        
        private readonly ITaskService _taskService;
        
        public TaskManagerController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("complete")]
        [ProducesResponseType(typeof(TaskResponse<CompleteTaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CompleteTask(CompleteTaskRequest request)
        {
            var requestDto = _mapper.Map<CompleteTaskRequestDto>(request);
            var result = await _taskService.CompleteTask(requestDto);
            return Ok(_mapper.Map<TaskResponse<CompleteTaskResponse>>(result));
        }
        
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(TaskResponse<CreateTaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateTask(CreateTaskRequest request)
        {
            var requestDto = _mapper.Map<CreateTaskRequestDto>(request);
            var result = await _taskService.CreateTask(requestDto);
            return Ok(_mapper.Map<TaskResponse<CreateTaskResponse>>(result));
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(TaskResponse<GetTaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTasks()
        {
            var result = await _taskService.GetTasks();
            return Ok(_mapper.Map<TaskResponse<GetTaskResponse>>(result));
        }
        
        [HttpDelete]
        [Route("remove")]
        [ProducesResponseType(typeof(TaskResponse<CloseTaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveTask(RemoveTaskRequest request)
        {
            var requestDto = _mapper.Map<RemoveTaskRequestDto>(request);
            var result = await _taskService.RemoveTask(requestDto);
            return Ok(_mapper.Map<TaskResponse<CloseTaskResponse>>(result));
        }
    }
}