using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Identity;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Statics;

namespace NeuroChecker.Backend.Service.Neuro.Controllers.Personal;

[ApiController, Route("/api/personal"), Authorize]
public class PersonalUserController(IIdentityService identityService) : ControllerBase
{
    [HttpPut("thresholds"), Authorize(Permissions.Personal.User.UpdateThresholds)]
    public async Task<IActionResult> UpdateUserThresholdsAsync([FromBody] UpdateThresholdsRequest request)
    {
        var dto = request.ToUpdateThresholdsDto();
        var result = await identityService.UpdateUserThresholdsAsync(User, dto);
        if (result) return Ok(new { Message = "User thresholds updated successfully." });

        return BadRequest(new { Message = "Failed to update user thresholds." });
    }
}