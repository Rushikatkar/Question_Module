using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionManagement.Data;
using QuestionManagement.Models;

namespace QuestionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.Include(q => q.Options).Include(q => q.Subject).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
                return NotFound();

            return question;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestion([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest("Invalid data.");
            }

            // Validate the question text
            if (string.IsNullOrWhiteSpace(question.Text))
            {
                return BadRequest("The question field is required.");
            }

            // Validate the subject ID
            if (question.SubjectId <= 0)
            {
                return BadRequest("The Subject field is required.");
            }

            // Add the question to the context
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            // Now add the options
            foreach (var option in question.Options)
            {
                option.QuestionId = question.Id; // Set the QuestionId for each option
                _context.Options.Add(option);
            }

            await _context.SaveChangesAsync();

            return Ok(new { Message = "Question created successfully!", QuestionId = question.Id });
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, Question updatedQuestion)
        {
            var question = await _context.Questions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null) return NotFound();

            question.Text = updatedQuestion.Text;
            question.Type = updatedQuestion.Type;
            question.Marks = updatedQuestion.Marks;
            question.Difficulty = updatedQuestion.Difficulty;
            question.SubjectId = updatedQuestion.SubjectId;
            question.ModelAnswer = updatedQuestion.ModelAnswer;

            if (updatedQuestion.Options != null)
            {
                _context.Options.RemoveRange(question.Options); // Remove old options
                question.Options = updatedQuestion.Options;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
                return NotFound();

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
