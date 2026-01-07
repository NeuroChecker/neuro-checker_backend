using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.Request.UserData;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Controllers.Personal;

[ApiController, Route("/api/personal/data"), Authorize]
public class PersonalUserDataController(
    ILocationRepository locationRepository,
    IUserDataRepository userDataRepository,
    IIdentityService identityService
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserDataAsync([FromBody] CreateUserDataRequest request
    )
    {
        var user = await identityService.GetUserByClaimsPrincipalAsync(User);
        if (user is null) return Unauthorized();

        var locationDto = await locationRepository.CreateAsync(request.Location.ToCreateDto());

        var userDataDto = await userDataRepository.CreateAsync(request.ToCreateDto(user.Id, locationDto.Id));
        var response = userDataDto.ToResponse();

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserDataAsync()
    {
        var user = await identityService.GetUserByClaimsPrincipalAsync(User);
        if (user is null) return Unauthorized();

        var userDataDtos = await userDataRepository.GetAllByUserIdAsync(user.Id);
        var responses = userDataDtos.Select(dto => dto.ToResponse()).ToList();

        return Ok(responses);
    }
}