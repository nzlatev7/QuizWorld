using System.ComponentModel.DataAnnotations;

namespace QuizMarket.Models.DB
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        //one to one
        public Answer Answer { get; set; }
    }
}