using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.MVC.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarWorkshopEntity> CarWorkshops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarWorkshopMVC;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
