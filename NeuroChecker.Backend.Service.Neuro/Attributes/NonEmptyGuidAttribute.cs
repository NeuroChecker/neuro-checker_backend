using System.ComponentModel.DataAnnotations;

namespace NeuroChecker.Backend.Service.Neuro.Attributes;

public class NonEmptyGuidAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return ValidationResult.Success;
        if (value is string str && Guid.TryParse(str, out var guid) && guid != Guid.Empty) return ValidationResult.Success;
        if (value is Guid guidValue && guidValue != Guid.Empty) return ValidationResult.Success;

        return new ValidationResult(ErrorMessage ?? "The field must be a non-empty GUID.");
    }
}