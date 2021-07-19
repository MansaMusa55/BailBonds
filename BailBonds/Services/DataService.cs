using BailBonds.Data;
using BailBonds.Enums;
using BailBonds.Models;
using BailBonds.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BailBonds.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBImageService _imageService;
        private readonly UserManager<BondsUser> _userManager;
        private readonly IConfiguration _configuration;
        public DataService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IBImageService imageService, UserManager<BondsUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _imageService = imageService;
            _userManager = userManager;
            _configuration = configuration;
        }

        


        public async Task ManageDataAsync()
        {
            //Task 0: Make sure the DB is present by running through the migration
            await _context.Database.MigrateAsync();
            //Task 1: Seed Roles and entering them into the system
            await SeedRolesAsync();
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //Are there any roles already in the system
            if (_context.Roles.Any())
                return;

            //Spin tough an enum and do stuff
            foreach (var role in Enum.GetNames(typeof(BondsRole)))
            {
                //Create a Role in the system for each role
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }


        private async Task SeedUsersAsync()
        {
            if (_context.Users.Any())
            {
                return;
            }
            var adminUser = new BondsUser()
            {
                Email = "SamCannon@mailinator.com",
                UserName = "SamCannon@mailinator.com",
                FirstName = "Samuel",
                LastName = "Cannon",
                PhoneNumber = "763-283-7237",
                EmailConfirmed = true,
                AvatarFileData = await _imageService.EncodeImageAsync("avatar3.png"),
                AvatarContentType = "png"
            };


            await _userManager.CreateAsync(adminUser, _configuration["AdminPassword"]);
            await _userManager.AddToRoleAsync(adminUser, BondsRole.Administrator.ToString());

        }
    }
}
