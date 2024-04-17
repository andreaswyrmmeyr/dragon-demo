using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class DragonDbContext : DbContext
{
    public DbSet<Dragon> Dragon {get; set; }

    public DragonDbContext(DbContextOptions<DragonDbContext> options) 
    : base (options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dragon>(entity => {
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Name).IsRequired();
            entity.Property(d => d.ImgUrl).IsRequired();
            entity.Property(d => d.Description).IsRequired();
            entity.Property(d => d.Age).IsRequired();
        });
    }
}