using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Web.Models;

public sealed class CreateTaskRequest
{
    [Required]
    [StringLength(250)]
    public string Title { get; init; }

    [Required]
    [StringLength(1000)]
    public string Description { get; init; }

    [Required]
    public DateTime DateTime { get; set; }

    public bool IsCompleted { get; set; }
}
