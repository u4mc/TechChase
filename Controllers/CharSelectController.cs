using Microsoft.AspNetCore.Mvc;
using TechChase.Models;

namespace TechChase.Controllers
{
    public class CharSelectController : Controller
    {
        IList<Character> characterList = new List<Character>() {
                    new Character("Sol Badguy","img"),
                    new Character("May","img"),
                };
        public IActionResult Index()
        {//Use a viewbag
            ViewBag.charlist = characterList;
            return View();
        }
    }
}
