using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Question_Module.Models;
using System.Text;

namespace Question_Module.Controllers
{
    public class QuestionController : Controller
    {
        private readonly HttpClient _httpClient;
        private string apiBaseUrl = "https://localhost:7177/api/Question"; // Updated API URL

        public QuestionController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(apiBaseUrl);
                if (!response.IsSuccessStatusCode) return View("Error");

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent); // Debugging step

                // Directly deserialize into a list
                var questions = JsonConvert.DeserializeObject<List<QuestionViewModel>>(responseContent);

                return View(questions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return View("Error");
            }

        }


        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiBaseUrl}/{id}");
                if (!response.IsSuccessStatusCode) return View("Error");

                var responseContent = await response.Content.ReadAsStringAsync();
                var question = JsonConvert.DeserializeObject<QuestionViewModel>(responseContent);

                if (question == null)
                {
                    return View("Error");  // Ensure the model is not null
                }

                return View(question);  // Pass the valid model to the view
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return View("Error");
            }
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            var model = new QuestionViewModel
            {
                // Ensure Options is initialized as an empty list
                Options = new List<OptionViewModel>()
            };
            return View(model);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(QuestionViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var jsonContent = JsonConvert.SerializeObject(new
            {
                text = model.QuestionText,
                type = model.QuestionType,
                marks = model.Marks,
                difficulty = model.DifficultyLevel,
                subjectId = model.TopicId,
                options = model.Options,
                modelAnswer = model.ModelAnswer
            });

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiBaseUrl, content);

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode) return View("Error");

            var responseContent = await response.Content.ReadAsStringAsync();
            var question = JsonConvert.DeserializeObject<QuestionViewModel>(responseContent);
            return View(question);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(QuestionViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var jsonContent = JsonConvert.SerializeObject(new
            {
                id = model.Id,
                text = model.QuestionText,
                type = model.QuestionType,
                marks = model.Marks,
                difficulty = model.DifficultyLevel,
                subjectId = model.TopicId,
                options = model.Options,
                modelAnswer = model.ModelAnswer
            });

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{apiBaseUrl}/{model.Id}", content);

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode) return View("Error");

            var responseContent = await response.Content.ReadAsStringAsync();
            var question = JsonConvert.DeserializeObject<QuestionViewModel>(responseContent);
            return View(question);
        }



        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                // Return an error page or redirect based on your app's needs
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
