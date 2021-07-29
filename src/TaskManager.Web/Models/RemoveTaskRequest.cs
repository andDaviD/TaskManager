using System.ComponentModel.DataAnnotations;

namespace TaskManager.Web.Models
{
    public sealed class RemoveTaskRequest
    {
        [Required]
        public int Id { get; init; }
    }
}