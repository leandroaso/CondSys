using System.Diagnostics;
using CondSys.DAO;
using Microsoft.AspNetCore.Mvc;
using CondSys.Models.ViewModel;

namespace CondSys.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
