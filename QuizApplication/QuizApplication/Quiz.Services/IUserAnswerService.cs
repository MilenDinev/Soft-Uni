using Quiz.Services.Models;

namespace Quiz.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string userId, int quizId, int questionId, int answerId);
        void BulkAddUserAnswer(QuizInputModel quizInputModel);
        public int GetUserResult(string userId, int quizId);

    }
}
