using QuizWeb.Models;
using QuizWeb.Data;
using Microsoft.EntityFrameworkCore;
namespace QuizWeb.DatabaseServices;

public partial class DatabaseServices
{
    public IEnumerable<Theme> GetAllTheme()
    {
        var result = _dbContext.Themes
                        .AsEnumerable();
        return result;
    }
    public async Task<Theme?> GetTheme(int? themeId)
    {
        var result = await _dbContext.Themes
                        .FirstOrDefaultAsync(i => i.Id == themeId);
        return result;
    }
    public async Task<bool> InsertNewTheme(Theme theme)
    {
        var existingTheme = _dbContext.Themes.Find(theme.Id);
        if (existingTheme == null)
        {
            _dbContext.Themes.Add(theme);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<bool> UpdateTheme(Theme theme)
    {
        var existingTheme = _dbContext.Themes.Find(theme.Id);
        if (existingTheme == null)
        {
            return false;
        }
        existingTheme.ThemeName = theme.ThemeName;
        existingTheme.ModifierDate = DateTime.Now;
        _dbContext.Themes.Update(existingTheme);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteTheme(Theme theme)
    {
        var existingTheme = _dbContext.Themes.Find(theme.Id);
        if (existingTheme == null)
        {
            return false;
        }
        _dbContext.Themes.Remove(existingTheme);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
