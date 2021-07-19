using BailBonds.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BailBonds.Data
{
    public class ApplicationDbContext : IdentityDbContext<BondsUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BailBonds.Models.Client> Client { get; set; }
        public DbSet<BailBonds.Models.Comment> Comment { get; set; }
    }
}
