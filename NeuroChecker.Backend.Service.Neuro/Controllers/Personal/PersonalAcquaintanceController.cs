using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Acquaintance;
using NeuroChecker.Backend.Service.Neuro.Models.Request.UserData;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Controllers.Personal;

[ApiController, Route("/api/personal/acquaintances"), Authorize]
public class PersonalAcquaintanceController(
    IUserRepository userRepository,
    IIdentityService identityService
) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> LinkAcquaintanceAsync([FromBody] LinkAcquaintanceRequest request)
    {
        var user = await identityService.GetUserByClaimsPrincipalAsync(User);
        if (user is null) return Unauthorized();

        var result = await userRepository.LinkAcquaintanceAsync(user.Id, request.AcquaintanceId);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{acquaintanceId:guid}")]
    public async Task<IActionResult> UnlinkAcquaintanceAsync([FromRoute] Guid acquaintanceId)
    {
        var user = await identityService.GetUserByClaimsPrincipalAsync(User);
        if (user is null) return Unauthorized();

        var result = await userRepository.UnlinkAcquaintanceAsync(user.Id, acquaintanceId);
        return result ? NoContent() : NotFound();
    }
}