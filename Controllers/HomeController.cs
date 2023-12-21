using Microsoft.AspNetCore.Mvc;

namespace UserManagementDummy.Controller
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
    }
}
