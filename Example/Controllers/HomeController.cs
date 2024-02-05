using Example.Models;
using Example.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Example.Controllers
{
	public class HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IUserRepository userRepository) : Controller
	{
		private readonly ILogger<HomeController> _logger = logger;
		private readonly IProductRepository _productRepository = productRepository;
		private readonly IUserRepository _userRepository = userRepository;

        public async Task<IActionResult> Index()
		{
			var users = await _userRepository.GetAllAsync();
			if(users != null)
				ViewBag.Users = users;
			return View();
		}
        public async Task<IActionResult> Products()
        {
            var products = await _productRepository.GetAllAsync();
            if (products != null)
                ViewBag.Products = products;
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
