using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int> // int burada key değeri(id ler guid değil int istiyoruz diye)
    {

        // Bağlantı adresimizi yazıyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-N2KFL21;initial catalog=ApiDb;integrated security=true;TrustServerCertificate=True;"); // TrustServerCertificate=True; bu eksik olduğu için yazdıramamışım
        }

        // Tablolar
        public DbSet<Room> Rooms { get; set; } // Room sınıf ismi, Rooms sql e yansıyacak tablo ismi
        public DbSet<Service> Services { get; set; } 
        public DbSet<Subscribe> Subscribes { get; set; } 
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
