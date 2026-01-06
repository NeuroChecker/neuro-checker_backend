using Microsoft.AspNetCore.Mvc;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Acquaintance;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Controllers;

[ApiController, Route("/api/users/{userId:guid}")]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    [HttpPut("acquaintances")]
    public async Task<IActionResult> LinkAcquaintanceAsync(
        [FromRoute] Guid userId,
        [FromBody] LinkAcquaintanceRequest request
    )
    {
        var result = await userRepository.LinkAcquaintanceAsync(userId, request.AcquaintanceId);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("acquaintances/{acquaintanceId:guid}")]
    public async Task<IActionResult> UnlinkAcquaintanceAsync(
        [FromRoute] Guid userId,
        [FromRoute] Guid acquaintanceId
    )
    {
        var result = await userRepository.UnlinkAcquaintanceAsync(userId, acquaintanceId);
        return result ? NoContent() : NotFound();
    }
}