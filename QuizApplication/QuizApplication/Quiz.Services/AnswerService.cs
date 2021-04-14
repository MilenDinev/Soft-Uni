using Quiz.Data;
using Quiz.Models;

namespace Quiz.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public AnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(string title, int points, bool isCorrect, int questionId)
        {
            var answer = new Answer
            {
                Title = title,
                Points = points,
                IsCorrect = isCorrect,
                QuestionId = questionId,
            };

            this.dbContext.Answers.Add(answer);
            this.dbContext.SaveChanges();

            return answer.Id;
        }
    }
}
