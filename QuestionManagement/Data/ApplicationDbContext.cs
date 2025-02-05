using Microsoft.EntityFrameworkCore;
using QuestionManagement.Models;

namespace QuestionManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure enum to be stored as a string
            modelBuilder.Entity<Question>()
                .Property(q => q.Type)
                .HasConversion<string>();

            // Subject Seeding
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Mathematics" },
                new Subject { Id = 2, Name = "Science" }
            );

            // Question Seeding
            modelBuilder.Entity<Question>().HasData(
                new Question 
                { 
                    Id = 1, 
                    Text = "What is 2 + 2?", 
                    Type = QuestionType.MCQ, 
                    Marks = 5, 
                    Difficulty = "Easy", 
                    SubjectId = 1,
                    ModelAnswer = ""
                },
                new Question 
                { 
                    Id = 2, 
                    Text = "The Earth is flat.", 
                    Type = QuestionType.TrueFalse, 
                    Marks = 5, 
                    Difficulty = "Easy", 
                    SubjectId = 2,
                    ModelAnswer = "False"
                },
                new Question 
                { 
                    Id = 3, 
                    Text = "Explain Newton's First Law of Motion.", 
                    Type = QuestionType.Descriptive, 
                    Marks = 10, 
                    Difficulty = "Hard", 
                    SubjectId = 2,
                    ModelAnswer = "An object remains at rest or in motion unless acted upon by an external force."
                }
            );

            // Options Seeding
            modelBuilder.Entity<Option>().HasData(
                new Option { Id = 1, Text = "3", IsCorrect = false, QuestionId = 1 },
                new Option { Id = 2, Text = "4", IsCorrect = true, QuestionId = 1 },
                new Option { Id = 3, Text = "True", IsCorrect = false, QuestionId = 2 },
                new Option { Id = 4, Text = "False", IsCorrect = true, QuestionId = 2 }
            );

            modelBuilder.Entity<Subject>().Navigation(s => s.Questions).AutoInclude();
        }
    }
}