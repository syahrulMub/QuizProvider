using Microsoft.EntityFrameworkCore;
using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public partial class DatabaseServices
{
    public IEnumerable<Chapter> GetAllChapter()
    {
        var result = _dbContext.Chapters
                    .Include(i => i.Theme)
                    .AsEnumerable();
        return result;
    }
    public async Task<Chapter?> GetChapter(int? chapterId)
    {
        var result = await _dbContext.Chapters
                    .FirstOrDefaultAsync(i => i.Id == chapterId);
        return result;
    }
    public async Task<bool> InsertNewChapter(Chapter chapter)
    {
        var existingChapter = _dbContext.Chapters.Find(chapter.Id);
        if (existingChapter != null)
        {
            return false;
        }
        else
        {
            _dbContext.Chapters.Add(chapter);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
    public async Task<bool> UpdateChapter(Chapter chapter)
    {
        var existingChapter = _dbContext.Chapters.Find(chapter.Id);
        if (existingChapter == null)
        {
            return false;
        }
        else
        {
            existingChapter.ChapterName = chapter.ChapterName;
            existingChapter.Description = chapter.Description;
            existingChapter.ModifierDate = DateTime.Now;
            _dbContext.Chapters.Update(existingChapter);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
    public async Task<bool> DeleteChapter(Chapter chapter)
    {
        var existingChapter = _dbContext.Chapters.Find(chapter.Id);
        if (existingChapter == null)
        {
            return false;
        }
        else
        {
            _dbContext.Chapters.Remove(existingChapter);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
    public bool CheckAvailableNameOfChapter(string chapterName)
    {
        var result = _dbContext.Chapters
                    .Select(i => i.ChapterName)
                    .AsEnumerable();
        foreach (var availableChapterName in result)
        {
            if (availableChapterName.ToLower().Contains(chapterName.ToLower()))
            {
                return false;
            }
        }
        return true;
    }
}
