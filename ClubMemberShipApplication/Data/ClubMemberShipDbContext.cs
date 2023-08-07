using System;
using ClubMemberShipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMemberShipApplication.Data
{
	public class ClubMemberShipDbContext: DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMemberShip.db");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}

