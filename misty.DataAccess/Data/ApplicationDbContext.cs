using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using misty.Models;
using MistyASP.DataAccess.Data;
using yessine.Models;

namespace MistyASP.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> {
        //ctor and tab to create the methode AppDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {



        }
        public DbSet<Catergory> catergories { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder); 
            
           

            


        }


         
    
    }
}
