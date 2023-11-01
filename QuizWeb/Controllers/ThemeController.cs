using Microsoft.AspNetCore.Mvc;
using QuizWeb.DatabaseServices;
using QuizWeb.Models;
namespace QuizWeb.Controllers;

[Produces("application/json")]
[Route("api/[Controller]")]
public class ThemeController : Controller
{
    private readonly IDatabaseServices _services;
    private readonly ILogger<ThemeController> _logger;
    public ThemeController(IDatabaseServices services, ILogger<ThemeController> logger)
    {
        _services = services;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult GetAllTheme()
    {
        try
        {
            var allTheme = _services.GetAllTheme();
            _logger.LogInformation("Success get all theme");
            return Json(allTheme);
        }
        catch (Exception ex)
        {
            _logger.LogError("error while request all theme : " + ex.Message);
            return StatusCode(500, "error while request all theme : " + ex.Message);
        }
    }
    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetTheme(int themeId)
    {
        try
        {
            var currentTheme = _services.GetTheme(themeId);
            _logger.LogInformation($"success getting Theme : {themeId}");
            return Json(currentTheme);
        }
        catch (Exception ex)
        {
            _logger.LogError($"error while getting Theme {themeId} : {ex.Message}");
            return StatusCode(500, "error while getting Theme {themeId} : {ex.Message}");
        }
    }
    [HttpPost]
    [Route("CreateTheme")]
    public async Task<IActionResult> CreateTheme([FromBody] string newThemeName)
    {
        Theme theme = new()

        {
            ThemeName = newThemeName,
            CreateDate = DateTime.Now,
            ModifierDate = DateTime.Now
        };
        try
        {
            var checkAvailableTheme = _services.CheckAvailableNameOfTheme(theme.ThemeName);
            if (!checkAvailableTheme)
            {
                _logger.LogError($"{theme.ThemeName} already exist");
                return StatusCode(500, "theme already exist");
            }
            else
            {
                await _services.InsertNewTheme(theme);
                _logger.LogInformation($"success create new theme {theme.ThemeName}");
                return Ok();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("error while creating new theme" + ex.Message);
            return StatusCode(500, "error while creating new theme" + ex.Message);
        }
    }
    [HttpPut]
    [Route("UpdateTheme")]
    public async Task<IActionResult> UpdateTheme(int themeId, [FromBody] string updateThemeName)
    {
        try
        {
            var existingTheme = await _services.GetTheme(themeId);
            if (existingTheme == null)
            {

                return NotFound();
            }
            else
            {
                existingTheme.ThemeName = updateThemeName;
                _logger.LogInformation($"success updating theme {existingTheme.ThemeName}");
                await _services.UpdateTheme(existingTheme);
                return Ok();
            }
        }
        catch (Exception ex)
        {

            _logger.LogError("rror while updating theme : " + ex.Message);
            return StatusCode(500, "error while updating theme : " + ex.Message);
        }
    }
    [HttpDelete]
    [Route("DeleteTheme")]
    public async Task<IActionResult> DeleteTheme(int themeId)
    {
        try
        {
            var existingTheme = await _services.GetTheme(themeId);
            if (existingTheme == null)
            {
                return NotFound();
            }
            else
            {
                await _services.DeleteTheme(existingTheme);
                _logger.LogInformation($"success delete {existingTheme.ThemeName}");
                return Ok();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("error while deleting theme : " + ex.Message);
            return StatusCode(500, "error while deleting theme : " + ex.Message);
        }
    }
}
