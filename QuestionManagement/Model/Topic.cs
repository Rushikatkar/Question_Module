using System.ComponentModel.DataAnnotations;
using QuestionManagement.Models;

public class Topic
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Topic name is required.")]
        public string Name { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>(); // Initialize here
    }