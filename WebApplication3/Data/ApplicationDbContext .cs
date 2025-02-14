using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Emploi> Emplois { get; set; }
       
     

    }
}
