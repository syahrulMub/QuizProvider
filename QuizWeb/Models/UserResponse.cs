using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizWeb.Models;

public class UserResponse : BaseModel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public string UserId { get; set; } = null!;
    [ForeignKey("QuizDetailId")]
    public int QuizDetailId { get; set; }
    [ForeignKey("AnswerQuizDetailId")]
    public int? AnswerQuizDetailId { get; set; }
    public string? UserAnswer { get; set; }
    public int Score { get; set; }

    public virtual AnswerQuizDetail AnswerQuizDetailQuizDetail { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual QuizDetail QuizDetail { get; set; } = null!;
}
