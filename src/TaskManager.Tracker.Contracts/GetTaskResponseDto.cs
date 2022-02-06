using System.Collections.Generic;

namespace TaskManager.Tracker.Contracts;

public sealed record GetTaskResponseDto(IEnumerable<TaskRecordDto> TaskRecords);
