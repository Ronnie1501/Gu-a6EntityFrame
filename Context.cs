using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Guía6EntityFrame
{
    public class Context : DbContext
    {
        public DbSet<Student> estudiante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6O6146B;Database=PrograDB; Trusted_Connection = SSPI; MultipleActiveResultSets = true; Trust Server Certificate = true; ");
        }
    }
}
