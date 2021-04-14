namespace Quiz.Services
{
    using Quiz.Data;
    using Quiz.Models;

    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext dbContext;

        public QuestionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(string title, int quizId)
        {
            var question = new Question
            {
                Title = title,
                QuizId = quizId
            };
            this.dbContext.Questions.Add(question);
            this.dbContext.SaveChanges();

            return question.Id;
        }
    }

}
