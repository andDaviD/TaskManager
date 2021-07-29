using System.Collections.Generic;

namespace TaskManager.Web.Models
{
    internal sealed record ErrorResponse(IEnumerable<string> Errors, int StatusCode);
}