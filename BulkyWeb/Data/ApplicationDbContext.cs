using System;
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
			): base(options)
		{
			
		}
		public DbSet<Categorty> Categorties { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Categorty>().HasData(
				new Categorty
				{
					Id = 1, Name = "Action", DisplayOrder = 1
				},
				new Categorty
				{
					Id = 2, Name = "SciFi", DisplayOrder = 2
				},
				new Categorty
				{
					Id = 3, Name = "History", DisplayOrder = 3
				}
			);
		}
		
	}
}

