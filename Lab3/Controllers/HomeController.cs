using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult SongForm() => View();

        [HttpPost]
        public IActionResult Sing() {
            // you will complete this
            HttpContext.Session.SetString("num", Request.Form["num"]);
            return View();
        }

        public IActionResult CreateStudent() => View();

        [HttpPost]
        public IActionResult DisplayStudent(Student student) {
            // you will complete this
            return View(student);
        }
        public IActionResult Error() {
            return View();
        }

    }
}
