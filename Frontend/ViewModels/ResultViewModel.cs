using static TansiqyFrontend.Models.ViewModels.ViewModel;

namespace TansiqyFrontend.ViewModels
{
    public class ResultViewModel
    {
        public List<FacultyViewModel> Faculties { get; set; }
        public List<UniversityViewModel> Universities { get; set; }
    }
}
