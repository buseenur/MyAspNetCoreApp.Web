using System;
using Microsoft.EntityFrameworkCore;

namespace MyAspNetCoreApp.Web.Models
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=TurkcellDb;uid=root; password=123456aA; Charset=utf8mb4",
                ServerVersion.AutoDetect("Server=127.0.0.1;Port=3306;Database=TurkcellDb;uid=root; password=123456aA; Charset=utf8mb4"));
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Product> Products { get; set; }
        

    }
}

