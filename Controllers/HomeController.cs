using Jardin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Jardin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Jardins J = new Jardins();
            J.Name = "Poudlard";
            _context.Jardins.Add(J);
            _context.SaveChanges();
            return View();
        }

        public IActionResult Privacy()
        {
            if(_context.Jardins.FirstOrDefault() == null)
            {
                Legume L1 = new Legume();
                L1.name = "Carotte";
                L1.description = "Beau et Bon.";
                L1.Vitamine = "Vitamine E";

                Fruit F1 = new Fruit();
                F1.name = "Pomme";
                F1.description = "Rouge";
                F1.Sucre = "10 grammes";

                List<Aliment> listeAliment = new List<Aliment>();
                listeAliment.Add(L1);
                listeAliment.Add(F1);

                Jardins J1 = new Jardins();
                J1.Surface = 10;
                J1.Emplacement = "Ici";
                J1.Aliment = listeAliment;

                _context.Add(L1);
                _context.Add(F1);
                _context.Add(J1);

                _context.SaveChanges();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}