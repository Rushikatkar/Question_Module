using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using QuestionManagement.Models;

public class Option
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Option text is required.")]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        [JsonIgnore]
        public Question Question { get; set; }
    }
