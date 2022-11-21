using System.ComponentModel.DataAnnotations;

namespace QuizMarket.Models.DB
{
    public class Quiz
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Topic { get; set; }
        public List<Question> listOfQuestion { get; set; }
        //many to many
        //public ICollection<User> Users { get; set; }
        //one to many
        public ICollection<Question> Questions { get; set; }
    }
}