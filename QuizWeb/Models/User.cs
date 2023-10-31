using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using QuizWeb.Constant;

namespace QuizWeb.Models;

public class User : IdentityUser
{
    public string? PictureProfile { get; set; }
    public string? SchoolName { get; set; }
    public SchoolClassEnum SchoolClass { get; set; }
    public SchoolLevelEnum SchoolLevel { get; set; }
}
