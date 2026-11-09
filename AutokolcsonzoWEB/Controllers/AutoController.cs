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

    }
}
