using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuestionManagement.Models
{
    public enum QuestionType
    {
        MCQ, TrueFalse, Descriptive
    }

    public class Question
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The question text is required.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "The question type is required.")]
        public QuestionType Type { get; set; }

        [Required(ErrorMessage = "Marks allocation is required.")]
        public int Marks { get; set; }

        public string? ModelAnswer { get; set; } // Nullable for descriptive questions

        [Required(ErrorMessage = "Difficulty level is required.")]
        public string Difficulty { get; set; } // Easy, Medium, Hard

        [Required(ErrorMessage = "Subject ID is required.")]
        public int SubjectId { get; set; }

        [JsonIgnore]
        public Subject Subject { get; set; }

        public ICollection<Option> Options { get; set; } = new List<Option>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>(); // Initialize here
    }
}