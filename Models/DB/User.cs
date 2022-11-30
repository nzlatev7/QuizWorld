using System.ComponentModel.DataAnnotations;

namespace QuizMarket.Models.DB
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public List<Quiz> ListOfQuiz { get; set; }
        //many to many
        public ICollection<Quiz> Quizzes { get; set; }

        //EmailValid
    }
}