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
                    Theme = chapter.Theme.ThemeName,
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
    [Route("{Id}")]
    public async Task<IActionResult> GetChapter(int chapterId)
    {
        try
        {
            var result = await _services.GetChapter(chapterId);
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
    [Route("CreateChapter")]
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
    [HttpPut]
    [Route("UpdateChapter")]
    public async Task<IActionResult> EditChapter(int chapterId, [FromBody] NewChaper newChapter)
    {
        try
        {

            var currentChapter = await _services.GetChapter(chapterId);
            var existingChapter = _services.GetAllChapter().Select(i => i.ChapterName);
            if (currentChapter != null)
            {
                currentChapter.ThemeId = newChapter.ThemeId;
                currentChapter.ChapterName = newChapter.ChapterName;
                currentChapter.Description = newChapter.Description;
                currentChapter.ModifierDate = DateTime.Now;
                foreach (var chap in existingChapter)
                {
                    if (chap.ToLower().Contains(newChapter.ChapterName.ToLower()))
                    {
                        _logger.LogError($"chapter with name {newChapter.ChapterName} already exist");
                        return StatusCode(500, $"Chapter with name {newChapter.ChapterName} already exist");
                    }
                }
                await _services.UpdateChapter(currentChapter);
                _logger.LogInformation($"success adding updating chapter {newChapter.ChapterName}");
                return Ok();
            }
            else
            {
                _logger.LogError("chapter not found");
                return StatusCode(500, "chapter not found");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("error while updating chapter : " + ex.Message);
            return StatusCode(500, "error while updating chapter : " + ex.Message);
        }
    }
    [HttpDelete]
    [Route("DeleteChapter")]
    public async Task<IActionResult> DeleteChapter(int chapterId)
    {
        try
        {
            var existingChapter = await _services.GetChapter(chapterId);
            if (existingChapter != null)
            {
                await _services.DeleteChapter(existingChapter);
                _logger.LogInformation($"Chapter {existingChapter.ChapterName} successfully deleted");
                return Ok($"Chapter {existingChapter.ChapterName} successfully deleted");
            }
            else
            {
                _logger.LogError("Chapter not found");
                return StatusCode(500, "Chapter not found");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("error while deleting chapter : " + ex.Message);
            return StatusCode(500, "error while deleting chapter : " + ex.Message);
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
    public string? Theme;
    public string? ChapterDescription;
    public DateTime? ChapterModifier;
}