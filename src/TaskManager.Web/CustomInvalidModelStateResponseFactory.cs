using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Web.Models;

namespace TaskManager.Web;

internal sealed class CustomInvalidModelStateResponseFactory
{
    public IActionResult Create(ActionContext context) =>
        new BadRequestObjectResult(new ErrorResponse(
            context.ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList(),
            (int)HttpStatusCode.BadRequest));
}
