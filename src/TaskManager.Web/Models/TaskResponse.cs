using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Web.Models
{
    internal sealed record TaskResponse<T>(T Payload, IEnumerable<string> Errors = null)
    {
        public bool Success => Errors == null || !Errors.Any();
    }
}