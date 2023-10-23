using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Models;

public class Chapter : BaseModel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Theme")]
    public int ThemeId { get; set; }
    [Required]
    public string ChapterName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual Theme Theme { get; set; } = null!;
}