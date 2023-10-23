using System.ComponentModel.DataAnnotations;

namespace QuizWeb.Models;

public class Theme : BaseModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ThemeName { get; set; } = null!;
}
