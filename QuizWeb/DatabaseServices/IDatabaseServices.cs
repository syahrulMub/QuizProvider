using QuizWeb.Models;

namespace QuizWeb.DatabaseServices;

public interface IDatabaseServices
{
    //Interface for theme
    public IEnumerable<Theme> GetAllTheme();
    public Task<Theme?> GetTheme(int? themeId);
    public Task<bool> InsertNewTheme(Theme theme);
    public Task<bool> UpdateTheme(Theme theme);
    public Task<bool> DeleteTheme(Theme theme);
    public bool CheckAvailableNameOfTheme(string themeName);

    //interface for chapter
    public IEnumerable<Chapter> GetAllChapter();
    public Task<Chapter?> GetChapter(int? chapterId);
    public Task<bool> InsertNewChapter(Chapter chapter);
    public Task<bool> UpdateChapter(Chapter chapter);
    public Task<bool> DeleteChapter(Chapter chapter);
    public bool CheckAvailableNameOfChapter(string chapterName);

    //interface for user
    // public Task<User> GetUserData(string Email);

    //interface for quiz
    public IEnumerable<Quiz> GetAllQuiz();
    public Task<Quiz?> GetQuiz(int? quizId);
    public Task<bool> CreateNewQuiz(Quiz quiz);
    public Task<bool> UpdateQuiz(Quiz quiz);
    public Task<bool> DeleteQuiz(Quiz quiz);

    //interface for quiz detail
    public IEnumerable<QuizDetail> GetAllQuizDetail();
    public Task<QuizDetail?> GetQuizDetail(int? quizDetailId);
    public Task<bool> CreateNewQuizDetail(QuizDetail quizDetail);
    public Task<bool> UpdateQuizDetail(QuizDetail quizDetail);
    public Task<bool> DeleteQuizDetail(QuizDetail quizDetail);

    //interface for answer quiz detail
    public IEnumerable<AnswerQuizDetail> GetAllAnswerQuizDetail(int quizDetailId);
    public Task<AnswerQuizDetail?> GetAnswerQuizDetail(int? answerQuizDetail);
    public Task<bool> CreateNewAnswerQuizDetail(AnswerQuizDetail answerQuizDetail);
    public Task<bool> UpdateAnswerQuizDetail(AnswerQuizDetail answerQuizDetail);
    public Task<bool> DeleteAnswerQuizDetail(AnswerQuizDetail answerQuizDetail);
}
