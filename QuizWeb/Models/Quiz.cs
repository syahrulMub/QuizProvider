using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuizWeb.Constant;
namespace QuizWeb.Models;

public class Quiz : BaseModel
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Chapter")]
    public int ChapterId { get; set; }
    public SchoolLevelEnum SchoolLevel { get; set; }
    public SchoolClassEnum SchoolClass { get; set; }
    public int ManyTimesDone { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;
}
