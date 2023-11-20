using AttendanceRegister.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AttendanceRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AttendanceRecord> AttendanceRecords{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = attendanceregisterdbserver.database.windows.net; Database = AttendanceRegister_db; User Id = Meso; Password = Qwerty@1; MultipleActiveResultSets = True; Trusted_Connection = False; Encrypt = True; ");
            }
        }
    }
}
