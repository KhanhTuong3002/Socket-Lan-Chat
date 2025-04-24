using BusinessObject.Entities;
using Client.Models;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAccess.Chat_Dbcontext _context; // Explicitly specify the namespace to resolve conflict
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, DataAccess.Chat_Dbcontext context, UserManager<AppUser> userManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Ensure _logger is initialized
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Ensure _context is initialized
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager)); // Ensure _userManager is initialized
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account"); // Handle null user scenario
            }

            ViewBag.currentUser = currentUser.UserName;

            // Ensure the 'Message' property exists in the DbContext
            var messages = await _context.Messages.ToListAsync(); // Corrected property name and method
            return View(); // Pass messages to the view
        }

        public async Task<IActionResult> Create(Message message)
        {
            if(ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await _userManager.GetUserAsync(User);
                message.SenderId = sender.Id;
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
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