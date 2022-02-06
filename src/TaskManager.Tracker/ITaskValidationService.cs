using System.Collections.Generic;
using TaskManager.Tracker.Contracts;

namespace TaskManager.Tracker;

internal interface ITaskValidationService
{
    List<string> ValidateCreateTaskRequest(CreateTaskRequestDto requestDto);
}
