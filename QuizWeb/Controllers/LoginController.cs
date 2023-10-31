using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.IdentityServices;
using QuizWeb.Models;

namespace QuizWeb.Controllers;

[Produces("application/json")]
[Route("api/[Controller]")]
public class LoginController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IIdentityServices _identityServices;
    private readonly ILogger<LoginController> _logger;
    public LoginController(IIdentityServices identityServices, ILogger<LoginController> logger, UserManager<User> userManager)
    {
        _userManager = userManager;
        _identityServices = identityServices;
        _logger = logger;
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        try
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                SchoolClass = model.SchoolClass,
                SchoolLevel = model.SchoolLevel,
                SchoolName = model.SchoolName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                return Ok(new { message = "Registration successful" });
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { message = "Registration failed", errors = errors });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("error while process registered : " + ex.Message);
            return StatusCode(500, "error while process registered : " + ex.Message);
        }
    }
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
    {
        try
        {
            var result = await _identityServices.LoginAsync(model);
            if (result != null)
            {
                var userData = _identityServices.GetUserData(model.Email);
                return Json(new { userData });
            }
            else
            {
                return Unauthorized();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("error while processing LogIn : " + ex.Message);
            return StatusCode(500, "error while processing LogIn : " + ex.Message);
        }
    }
}
