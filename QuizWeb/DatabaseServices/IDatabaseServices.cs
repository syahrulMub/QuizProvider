using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public interface IDatabaseServices
{
    //Interface for theme
    public IEnumerable<Theme> GetAllTheme();
    public Task<Theme?> GetTheme(int? themeId);
    public Task<bool> InsertNewTheme(Theme theme);
    public Task<bool> UpdateTheme(Theme theme);
    public Task<bool> DeleteTheme(Theme theme);

    //interface for chapter
    public IEnumerable<Chapter> GetAllChapter();
    public Task<Chapter?> GetChapter(int? chapterId);
    public Task<bool> InsertNewChapter(Chapter chapter);
    public Task<bool> UpdateChapter(Chapter chapter);
    public Task<bool> DeleteChapter(Chapter chapter);
}
