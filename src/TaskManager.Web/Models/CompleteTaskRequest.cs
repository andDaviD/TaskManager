using System.ComponentModel.DataAnnotations;

namespace TaskManager.Web.Models
{
    public sealed class CompleteTaskRequest
    {
        [Required]
        public int Id { get; init; }
    };
    
}