using System.ComponentModel.DataAnnotations;

namespace TaskManager.Web.Models;

public sealed class CloseTaskRequest
{
    [Required]
    public int Id { get; init; }
}
