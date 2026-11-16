using AutokolcsonzoLibrary.Models;
using AutokolcsonzoLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutokolcsonzoWEB.Controllers
{

    public class UgyfelController : Controller
    {
        private readonly IAutokolcsonzoService s;

        public UgyfelController(IAutokolcsonzoService service)
        {
            s = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Osszes()
        {
            return View(s.Ugyfelek());
        }

        public IActionResult Uj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Uj(Ugyfel u)
        {
            if (ModelState.IsValid)
            {
                if (s.UjUgyfel(u))
                {
                    return RedirectToAction("Osszes");
                }
            }

            return View(u);
        }
    }
}
