using System.ComponentModel.DataAnnotations;

namespace QuizMarket.Models.DB
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        //one to one
        public Question Question { get; set; }
    }
}