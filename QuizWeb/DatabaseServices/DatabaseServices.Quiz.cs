using Microsoft.EntityFrameworkCore;
using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public partial class DatabaseServices
{
    public IEnumerable<Quiz> GetAllQuiz()
    {
        var quizzes = _dbContext.Quizzes
                        .AsEnumerable();
        return quizzes;
    }
    public async Task<Quiz?> GetQuiz(int? quizId)
    {
        var currentQuiz = await _dbContext.Quizzes
                            .FirstOrDefaultAsync(i => i.Id == quizId);
        return currentQuiz;
    }
    public async Task<bool> CreateNewQuiz(Quiz quiz)
    {
        if (quiz != null)
        {
            _dbContext.Quizzes.Add(quiz);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<bool> UpdateQuiz(Quiz quiz)
    {
        var currentQuiz = _dbContext.Quizzes.Find(quiz.Id);
        if (currentQuiz == null)
        {
            return false;
        }
        else
        {
            currentQuiz.ChapterId = quiz.ChapterId;
            currentQuiz.SchoolClass = quiz.SchoolClass;
            currentQuiz.SchoolLevel = quiz.SchoolLevel;
            currentQuiz.ModifierDate = DateTime.Now;

            _dbContext.Quizzes.Update(currentQuiz);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
    public async Task<bool> DeleteQuiz(Quiz quiz)
    {
        var currentQuiz = _dbContext.Quizzes.Find(quiz.Id);
        if (currentQuiz == null)
        {
            return false;
        }
        else
        {
            _dbContext.Quizzes.Remove(quiz);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
