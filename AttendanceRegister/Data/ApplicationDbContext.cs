using AttendanceRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AttendanceRecord> AttendanceRecords{ get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AttendanceRecord>()
        //        .Property(p => p.RowVersion)
        //        .IsRowVersion(); // Configure RowVersion as a
        //                         // timestamp for optimistic concurrency control
        //}
    }
}
