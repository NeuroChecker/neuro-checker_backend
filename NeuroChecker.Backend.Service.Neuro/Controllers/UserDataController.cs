using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.Request.UserData;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Controllers;

[ApiController, Route("/api/users/{userId:guid}/data")]
public class UserDataController(
    ILocationRepository locationRepository,
    IUserDataRepository userDataRepository
) : ControllerBase
{
    
    // TODO - Check if needed, already implemented in PersonalUserDataController
    // [HttpPost]
    // public async Task<IActionResult> CreateUserDataAsync(
    //     [FromRoute] Guid userId,
    //     [FromBody] CreateUserDataRequest request
    // )
    // {
    //     var locationDto = await locationRepository.CreateAsync(request.Location.ToCreateDto());
    //
    //     var userDataDto = await userDataRepository.CreateAsync(request.ToCreateDto(userId, locationDto.Id));
    //     var response = userDataDto.ToResponse();
    //
    //     return Ok(response);
    // }
    //
    // [HttpGet]
    // public async Task<IActionResult> GetUserDataAsync([FromRoute] Guid userId)
    // {
    //     var userDataDtos = await userDataRepository.GetAllByUserIdAsync(userId);
    //     var responses = userDataDtos.Select(dto => dto.ToResponse()).ToList();
    //
    //     return Ok(responses);
    // }
}