using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using QuestionManagement.Models;

public class Subject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject name is required.")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
