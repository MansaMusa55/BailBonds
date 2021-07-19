using BailBonds.Data;
using BailBonds.Models;
using BailBonds.Models.ViewModel;
using BailBonds.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BailBonds.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBImageService _imageService;
        private readonly UserManager<BondsUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IBImageService imageService, UserManager<BondsUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _imageService = imageService;
            _userManager = userManager;
            _context = context;
        }
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            
          
            BondsUser bondsUser = await _userManager.GetUserAsync(User);
            DashboardViewModel model = new()
            {
                CurrentImage = _imageService.DecodeImage(bondsUser.AvatarFileData, bondsUser.AvatarContentType),         
                Clients = await _context.Client.ToListAsync()
            };
            return View(model);
        }
        public IActionResult Landing()
        {
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
