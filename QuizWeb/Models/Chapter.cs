using System.ComponentModel.DataAnnotations;

namespace QuizWeb.Models;

public class Chapter
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int LessonThemeId { get; set; }
    [Required]
    public string ChapterName { get; set; } = null!;
    public string? Description { get; set; }

    public virtual Theme Theme { get; set; } = null!;
}