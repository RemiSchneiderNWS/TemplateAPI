using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateAPI.Models;

namespace TemplateAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=TemplateAPi;Integrated Security=True;TrustServerCertificate=true");
        }
        public DbSet<Objet> objet { get; set; }  
        public DbSet<Utilisateurs> utilisateurs { get; set; }

    }
}
