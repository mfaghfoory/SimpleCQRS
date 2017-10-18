using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.Commands;
using SimpleCQRS.Infrastracture;
using SimpleCQRS.Models;
using SimpleCQRS.Queries;

namespace SimpleCQRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppBus _appBus;

        public HomeController(AppBus appBus)
        {
            _appBus = appBus;
        }

        public IActionResult Index()
        {
            _appBus.SendCommand(new TestCommand {Name = "hello world"});
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = await _appBus.SendQueryAsync<TestQuery, int>(new TestQuery {X = 23, Y = 20});

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}