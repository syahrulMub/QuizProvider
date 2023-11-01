using Microsoft.EntityFrameworkCore;
using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public partial class DatabaseServices
{
    public IEnumerable<AnswerQuizDetail> GetAllAnswerQuizDetail(int quizDetailId)
    {
        var answerQuizDetail = _dbContext.AnswerQuizDetails
                                .Where(i => i.QuizDetailId == quizDetailId)
                                .AsEnumerable();
        return answerQuizDetail;
    }
    public async Task<AnswerQuizDetail?> GetAnswerQuizDetail(int? answerQuizDetail)
    {
        var curremtAnswerQuizDetail = await _dbContext.AnswerQuizDetails
                                        .FirstOrDefaultAsync(i => i.Id == answerQuizDetail);
        return curremtAnswerQuizDetail;
    }
    public async Task<bool> CreateNewAnswerQuizDetail(AnswerQuizDetail answerQuizDetail)
    {
        if (answerQuizDetail != null)
        {
            _dbContext.AnswerQuizDetails.Add(answerQuizDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<bool> UpdateAnswerQuizDetail(AnswerQuizDetail answerQuizDetail)
    {
        var currentAnswerDetail = _dbContext.AnswerQuizDetails.Find(answerQuizDetail.Id);
        if (currentAnswerDetail != null)
        {
            currentAnswerDetail.TextAnswer = answerQuizDetail.TextAnswer;
            currentAnswerDetail.IsCorrect = answerQuizDetail.IsCorrect;
            currentAnswerDetail.ModifierDate = DateTime.Now;

            _dbContext.AnswerQuizDetails.Update(currentAnswerDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
