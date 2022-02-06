using System.Collections.Generic;

namespace TaskManager.Web.Models;

internal sealed record GetTaskResponse(IEnumerable<TaskRecord> TaskRecords);
