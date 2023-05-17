using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //Nome do método é mapeado para ação!
        {
            return View();
        }

        public IActionResult About()
        {
            //ViewData é um objeto dictionary (coleção de pares chave - valor)
            ViewData["Message"] = "Sales Web MVC App from c# course";
            ViewData["Professor"] = "Nelio Alves";

            return View(); //Method builder: Método auxiliar que vai retornar um objeto do tipo IActionResult
            //Irá procurar na pasta Views, na subpasta home a página About
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
