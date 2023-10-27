using Microsoft.AspNetCore.Identity;
using QuizWeb.Constant;
using QuizWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace QuizWeb.IdentityServices;

public class IdentityServices : IIdentityServices
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public IdentityServices(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;

    }
    public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
    {
        var user = new User { CompleteName = model.CompleteName, Email = model.Email, SchoolName = model.SchoolName };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "user");
        }
        return result;
    }
    public async Task<SignInResult> LoginAsync(LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
        return result;
    }
    public async Task<UserData?> GetUserData(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var role = await _userManager.GetRolesAsync(user);
            var userData = new UserData
            {
                Id = user.Id,
                Email = user.Email,
                SchoolClass = user.SchoolClass,
                SchoolLevel = user.SchoolLevel,
                Role = role.ToList(),
            };
            return userData;
        }
        return null;
    }
}
public class RegisterViewModel
{
    [Required]
    public string CompleteName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public string? SchoolName { get; set; }
    public SchoolClassEnum SchoolClass { get; set; }
    public SchoolLevelEnum SchoolLevel { get; set; }
}
public class LoginViewModel
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
public class UserData
{
    public string Id { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public SchoolClassEnum SchoolClass { get; set; }
    public SchoolLevelEnum SchoolLevel { get; set; }
    public IEnumerable<string> Role { get; set; } = null!;
}