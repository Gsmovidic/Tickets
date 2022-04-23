using Microsoft.EntityFrameworkCore;
using Tickets.Data.Entities;
using Tickets.Models;

namespace Tickets.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Entrance> Entrances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().HasIndex(t=>t.Id).IsUnique();
            modelBuilder.Entity<Entrance>().HasIndex(e=>e.Id).IsUnique();
            
        }

        public DbSet<Tickets.Models.TicketVM2> TicketVM2 { get; set; }
    }
}
