using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Models;

public class AnswerQuizDetail : BaseModel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("QuizDetailId")]
    public int QuizDetailId { get; set; }
    public string TextAnswer { get; set; } = null!;
    public bool IsCorrect { get; set; }

    public virtual QuizDetail QuizDetail { get; set; } = null!;
}
