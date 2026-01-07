using System.ComponentModel.DataAnnotations;

namespace NeuroChecker.Backend.Service.Neuro.Models.Request.Identity;

public class RegisterRequest
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required, MinLength(6), MaxLength(255)]
    public string Password { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Pronouns { get; set; } = null!;
}