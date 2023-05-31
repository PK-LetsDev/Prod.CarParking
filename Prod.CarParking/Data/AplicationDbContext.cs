using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prod.CarParking.Models;
using System.Collections;

namespace Prod.CarParking.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public override int SaveChanges()
    {
        this.EnsureAutoHistory();
        return base.SaveChanges();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.EnableAutoHistory();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<QueueNumber> Queues { get; set; }
    public DbSet<ParkingSlot> ParkingSlots { get; set; }

   
}