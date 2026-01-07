using NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Identity;

namespace NeuroChecker.Backend.Service.Neuro.Mapper;

public static class IdentityMapper
{
    public static RegisterUserDto ToRegisterDto(this RegisterRequest request) => new(
        request.Email,
        request.Password,
        request.Pronouns
    );

    public static LoginUserDto ToLoginDto(this LoginRequest request) => new(
        request.Email,
        request.Password
    );
}