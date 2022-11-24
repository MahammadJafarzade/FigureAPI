using Microsoft.EntityFrameworkCore;
using WebApplication1.Figures;

namespace WebApplication1.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Triangle> Triangles { get; set; }
        public DbSet<Point> Points { get; set; }
    }
}
