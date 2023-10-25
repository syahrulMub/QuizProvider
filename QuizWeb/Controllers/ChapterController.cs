using Microsoft.AspNetCore.Mvc;
using QuizWeb.DatabaseServices;
using QuizWeb.Models;

namespace QuizWeb.Controllers;

[Produces("application/json")]
[Route("api/[Controller]")]
public class ChapterController : Controller
{
    private readonly IDatabaseServices _services;
    public readonly Logger<ChapterController> _logger;
    public ChapterController(IDatabaseServices services, Logger<ChapterController> logger)
    {
        _services = services;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult GetAllChapter()
    {
        try
        {
            var allChapter = _services.GetAllChapter();
            _logger.LogInformation("success get all chapter");
            List<DTOAllChapter> allChaptersReturn = new();
            foreach (var chapter in allChapter)
            {
                var result = new DTOAllChapter
                {
                    ChapterName = chapter.ChapterName,
                    ChapterTheme = chapter.Theme.ThemeName,
                    ChapterDescription = chapter.Description,
                    ChapterModifier = chapter.ModifierDate,
                };
                allChaptersReturn.Add(result);
            }
            return Json(allChapter);
        }
        catch (Exception ex)
        {
            _logger.LogError("error while getting all chapter : " + ex.Message);
            return StatusCode(500, "error while getting all chapter : " + ex.Message);
        }
    }
    [HttpGet]
    [Route("Chapter/{id}")]
    public async Task<IActionResult> GetChapter(int chapterId)
    {
        try
        {
            var result = _services.GetChapter(chapterId);
            _logger.LogInformation($"success get chapter {chapterId}");
            return Json(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("error while proseccing chapter : " + ex.Message);
            return StatusCode(500, "error while proseccing chapter : " + ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewChapter([FromBody] NewChaper newChaper)
    {
        Chapter chapter = new()
        {
            ThemeId = newChaper.ThemeId,
            ChapterName = newChaper.ChapterName,
            Description = newChaper.Description,
            CreateDate = DateTime.Now,
            ModifierDate = DateTime.Now
        };
        try
        {
            var existingChapter = _services.GetAllChapter().Select(i => i.ChapterName);
            foreach (var chap in existingChapter)
            {
                if (chap.ToLower().Contains(chapter.ChapterName.ToLower()))
                {
                    _logger.LogError("chapter already exist");
                    return StatusCode(500, $"Chapter with name {chapter.ChapterName} already exist");
                }
            }
            await _services.InsertNewChapter(chapter);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("error while adding chapter : " + ex.Message);
            return StatusCode(500, "error while adding chapter : " + ex.Message);
        }
    }
}

public class NewChaper
{
    public int ThemeId { get; set; }
    public string ChapterName { get; set; } = null!;
    public string? Description { get; set; }
}


internal class DTOAllChapter
{
    public string? ChapterName;
    public string? ChapterTheme;
    public string? ChapterDescription;
    public DateTime? ChapterModifier;
}