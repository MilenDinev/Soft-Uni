using System.Collections.Generic;

namespace Quiz.Services.Models
{
    public class QuizInputModel
    {
        public string IdentityUserId { get; set; }
        public int QuizId { get; set; }
        public ICollection<QuestionInputModel> Questions { get; set; }
    }
}
