using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public UserAnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddUserAnswer(string userId, int quizId, int questionId, int answerId)
        {
            var userAnswer = new UserAnswer
            {
                IdentityUserId = userId,
                QuizId = quizId,
                QuestionId = questionId,
                AnswerId = answerId
            };

            dbContext.UserAnswers.Add(userAnswer);
            dbContext.SaveChanges();
        }


        public void BulkAddUserAnswer(QuizInputModel quizInputModel )
        {
            var userAnswers = new List<UserAnswer>();

            foreach (var question in quizInputModel.Questions)
            {
                var userAnswer = new UserAnswer
                {
                    IdentityUserId = quizInputModel.IdentityUserId,
                    QuizId = quizInputModel.QuizId,
                    AnswerId = question.AnswerId,
                    QuestionId = question.QuestionId
                };

                userAnswers.Add(userAnswer);
            }

            this.dbContext.UserAnswers.AddRange(userAnswers);
            this.dbContext.SaveChanges();
        }


        public int GetUserResult(string userId, int quizId)
        {
            var originalQuiz = this.dbContext.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var userAnswers = this.dbContext.UserAnswers
                .Where(x => x.IdentityUserId == userId && x.QuizId == quizId)
                .ToList();


            int? totalPoints = 0;
            foreach (var userAnswer in userAnswers)
            {
                totalPoints += originalQuiz.Questions
                    .FirstOrDefault(x => x.Id == userAnswer.QuestionId)
                    .Answers
                    .Where(x => x.IsCorrect)
                    .FirstOrDefault(x => x.Id == userAnswer.AnswerId)
                    ?.Points;
            }

            return totalPoints.GetValueOrDefault();
        }

    }
}
