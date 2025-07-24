using Microsoft.EntityFrameworkCore;

namespace TravelTripProje.Models.Sınıflar
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Adminsınıf> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletişim> Iletişims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }

    }
}
