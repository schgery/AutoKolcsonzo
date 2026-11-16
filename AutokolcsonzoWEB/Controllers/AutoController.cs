using AutokolcsonzoLibrary.Models;
using AutokolcsonzoLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Security.Cryptography.Xml;

namespace AutokolcsonzoWEB.Controllers
{
    public class AutoController : Controller
    {
        private readonly IAutokolcsonzoService s;

        public AutoController(IAutokolcsonzoService service)
        {
            s = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Osszes()
        {
            return View(s.Autok());
        }
        public IActionResult Szabad()
        {
            return View(s.SzabadAutok());
        }
        public IActionResult Ujgyarto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ujgyarto(Gyarto gy)
        {
            if (ModelState.IsValid)
            {
                s.UjGyarto(gy);
            }
            return RedirectToAction("gyartok");
        }
        public IActionResult Gyartok()
        {
            return View(s.Gyartok());
        }
        public IActionResult Kategoriak()
        {
            return View(s.Kategoriak());
        }
        public IActionResult Ujkategoria()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ujkategoria(Kategoria kat)
        {
            if (ModelState.IsValid)
            {
                s.UjKategoria(kat);
            }
            return RedirectToAction("kategoriak");
        }
    }
}