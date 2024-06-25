using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sube1.EntityApp
{
    internal class OkulDbContext:DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulDbEf;Integrated Security=true;TrustServerCertificate=true");
        }
    }
}
