using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static TansiqyFrontend.ViewModels;

namespace TansiqyFrontend.Controllers
{
    public class SearchController : Controller
    {
        private readonly HttpClient _httpClient;

        public SearchController(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7163/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/degrees");
            var degrees = new List<DegreeViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                degrees = JsonConvert.DeserializeObject<List<DegreeViewModel>>(json);
            }

            return View(degrees);
        }

        [HttpPost]
        public async Task<IActionResult> Results(int degId)
        {
            var faculties = new List<FacultyViewModel>();
            var universities = new List<UniversityViewModel>();

            var facRes = await _httpClient.GetAsync($"api/faculties?degreeId={degId}");
            if (facRes.IsSuccessStatusCode)
            {
                var json = await facRes.Content.ReadAsStringAsync();
                faculties = JsonConvert.DeserializeObject<List<FacultyViewModel>>(json);
            }

            var uniRes = await _httpClient.GetAsync($"api/universities?degreeId={degId}");
            if (uniRes.IsSuccessStatusCode)
            {
                var json = await uniRes.Content.ReadAsStringAsync();
                universities = JsonConvert.DeserializeObject<List<UniversityViewModel>>(json);
            }

            var vm = new ResultViewModel
            {
                Faculties = faculties,
                Universities = universities
            };

            return View(vm);
        }
    }

}
