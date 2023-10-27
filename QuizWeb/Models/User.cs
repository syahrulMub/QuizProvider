using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using QuizWeb.Constant;

namespace QuizWeb.Models;

public class User : IdentityUser
{
    [Required]
    [MaxLength(20)]
    public string CompleteName { get; set; } = null!;
    public string? PictureProfile { get; set; }
    public string? SchoolName { get; set; }
    [Required]
    public SchoolClassEnum SchoolClass { get; set; }
    [Required]
    public SchoolLevelEnum SchoolLevel { get; set; }
}
