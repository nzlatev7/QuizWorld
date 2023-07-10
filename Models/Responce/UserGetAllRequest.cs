using QuizMarket.Models.DB;

namespace QuizMarket.Models.Response
{
    public class UserGetAllResponce
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        //public IEnumerable<Quiz> ListOfQuiz { get; set; }
    }
}