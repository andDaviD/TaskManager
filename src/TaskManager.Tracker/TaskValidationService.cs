using System.Collections.Generic;
using TaskManager.Tracker.Contracts;

namespace TaskManager.Tracker;

internal sealed class TaskValidationService : ITaskValidationService
{
    private const int TitleMaxLength = 250;
    private const int DescriptionMaxLength = 1000;
    private readonly IDateTimeProvider _dateTimeProvider;

    public TaskValidationService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public List<string> ValidateCreateTaskRequest(CreateTaskRequestDto requestDto)
    {
        var errors = new List<string>();
        if (requestDto == null)
        {
            errors.Add("The request must be initialized.");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(requestDto.Title))
        {
            errors.Add("The title is required.");
        }
        else if (requestDto.Title.Length > TitleMaxLength)
        {
            errors.Add($"The title should not exceed {TitleMaxLength} characters.");
        }

        if (string.IsNullOrWhiteSpace(requestDto.Description))
        {
            errors.Add("The description is required.");
        }
        else if (requestDto.Description.Length > DescriptionMaxLength)
        {
            errors.Add($"The description should not exceed {DescriptionMaxLength} characters.");
        }

        if (requestDto.DateTime < _dateTimeProvider.Now)
        {
            errors.Add("The date should be in the future.");
        }

        return errors;
    }
}
