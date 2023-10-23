using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public interface IDatabaseServices
{
    public IEnumerable<Theme> GetAllTheme();
    public Task<Theme?> GetTheme(int? themeId);
    public Task<bool> InsertNewTheme(Theme theme);
    public Task<bool> UpdateTheme(Theme theme);
    public Task<bool> DeleteTheme(Theme theme);
}
