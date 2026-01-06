using System.ComponentModel.DataAnnotations;
using NeuroChecker.Backend.Service.Neuro.Attributes;

namespace NeuroChecker.Backend.Service.Neuro.Models.Request.Acquaintance;

public class LinkAcquaintanceRequest
{
    [Required, NonEmptyGuid] public Guid AcquaintanceId { get; set; }
}