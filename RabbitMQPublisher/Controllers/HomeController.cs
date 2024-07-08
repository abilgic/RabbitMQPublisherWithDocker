using Microsoft.AspNetCore.Mvc;
using RabbitMQPublisher.Models;
using System.Diagnostics;

namespace RabbitMQPublisher.Controllers
{
    public class HomeController : Controller
    {
        private readonly RabbitMQService _rabbitMQService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(RabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }


        public IActionResult Index()
        {
            _rabbitMQService.SendMessage("myQueue", "Hello RabbitMQ!");

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
