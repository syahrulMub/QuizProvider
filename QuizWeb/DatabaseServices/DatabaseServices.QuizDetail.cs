using System.Collections;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public partial class DatabaseServices
{
    public IEnumerable<QuizDetail> GetAllQuizDetail()
    {
        return _dbContext.QuizDetails
                .AsEnumerable();
    }
    public async Task<QuizDetail?> GetQuizDetail(int? quizDetailId)
    {
        var currentQuizDetail = await _dbContext.QuizDetails
                                        .FirstOrDefaultAsync(i => i.Id == quizDetailId);
        return currentQuizDetail;
    }
    public async Task<bool> CreateNewQuizDetail(QuizDetail quizDetail)
    {
        if (quizDetail != null)
        {
            _dbContext.QuizDetails.Add(quizDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<bool> UpdateQuizDetail(QuizDetail quizDetail)
    {
        var currentQuizDetail = _dbContext.QuizDetails.Find(quizDetail.Id);
        if (currentQuizDetail != null)
        {
            currentQuizDetail.Question = quizDetail.Question;
            currentQuizDetail.QuestionType = quizDetail.QuestionType;
            currentQuizDetail.Picture = quizDetail.Picture;

            _dbContext.QuizDetails.Update(currentQuizDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<bool> DeleteQuizDetail(QuizDetail quizDetail)
    {
        var currentQuizDetail = _dbContext.QuizDetails.Find(quizDetail.Id);
        if (currentQuizDetail != null)
        {
            _dbContext.QuizDetails.Remove(currentQuizDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
