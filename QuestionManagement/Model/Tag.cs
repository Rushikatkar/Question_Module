using System.ComponentModel.DataAnnotations;
using QuestionManagement.Models;

public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tag name is required.")]
        public string Name { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>(); // Change to List<Question> for direct relationship
    }