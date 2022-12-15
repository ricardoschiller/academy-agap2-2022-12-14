using Agap2IT.Academy.SuperMarket.Business;
using Agap2IT.Academy.SuperMarket.Dal;
using Agap2IT.Academy.SuperMarket.WebApp.Models;
using Agap2IT.Academy.SuperMarket.WebApp.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agap2IT.Academy.SuperMarket.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var clientsBO = new ClientsBO(new GenericDao());

            var opResult = await clientsBO.GetAllClients();

            if (opResult.HasSucceeded)
            {
                return View(new IndexViewModel { Clients = opResult.Result });
            }
            else
            {
                return View("Error");
            }
            
            
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