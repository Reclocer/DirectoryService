//using DirectoryService.Application;
//using DirectoryService.Contracts.Locations;

using CSharpFunctionalExtensions;
using DirectoryService.Application.Locations.Create;
using DirectoryService.Contracts.Location;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presenters.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLocationCommand command,
        [FromServices] CreateLocationHandler handler,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(command, cancellationToken);
    
        if (result.IsFailure)
            return BadRequest(result.Error);
       
        return CreatedAtAction(nameof(Create), result.Value);
    }
}