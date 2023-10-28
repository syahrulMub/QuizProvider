using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWeb.IdentityServices;

namespace QuizWeb.Controllers;

[Produces("application/json")]
[Route("api/[Controller]")]
public class LoginController : Controller
{
    private readonly IIdentityServices _identityServices;
    private readonly ILogger<LoginController> _logger;
    public LoginController(IIdentityServices identityServices, ILogger<LoginController> logger)
    {
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
            await _identityServices.RegisterUserAsync(model);
            // if (result.Succeeded)
            // {
            return Ok(new { message = "Register successfull" });
            // }
            // else
            // {
            //     return Unauthorized(new { message = "login Failed" });
            // }
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
