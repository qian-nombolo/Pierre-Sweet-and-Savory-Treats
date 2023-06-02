using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SweetSavoryTreats.Models
{
  public class SweetSavoryTreatsContext : IdentityDbContext<ApplicationUser>
  {

    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<TreatFlavor> TreatFlavors { get; set; }
    
    public DbSet<OrderTreat> OrderTreats { get; set; }

    public SweetSavoryTreatsContext(DbContextOptions options) : base(options) { }
  }
}
