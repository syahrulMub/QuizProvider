using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuizWeb.Constant;

namespace QuizWeb.Models;

public class QuizDetail : BaseModel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    [Required]
    public string Question { get; set; } = null!;
    [Required]
    public QuestionTypeEnum QuestionType { get; set; }
    public string? Picture { get; set; }
    public virtual Quiz Quiz { get; set; } = null!;
}
