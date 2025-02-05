using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Question_Module.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [JsonProperty("text")]
        public string QuestionText { get; set; }

        [Required]
        [JsonProperty("type")]
        public int QuestionType { get; set; } // Enum values: 0 = MCQ, 1 = True/False, 2 = Descriptive

        [Required]
        [JsonProperty("marks")]
        public int Marks { get; set; }

        [Required]
        [JsonProperty("difficulty")]
        public string DifficultyLevel { get; set; } // Easy, Medium, Hard

        [Required]
        [JsonProperty("subjectId")]
        public int TopicId { get; set; } // Mapped from SubjectId in API

        [JsonProperty("options")]
        public List<OptionViewModel> Options { get; set; } = new List<OptionViewModel>();

        [JsonProperty("modelAnswer")]
        public string? ModelAnswer { get; set; }

        public bool? CorrectAnswer { get; set; } // Used for True/False

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        public string Topic { get; set; }
        public string Subject { get; set; }
    }

    public class OptionViewModel
    {
        public int Id { get; set; }

        [JsonProperty("text")]
        public string OptionText { get; set; }

        [JsonProperty("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
