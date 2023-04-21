using Microsoft.EntityFrameworkCore;

namespace Models {

    public class GradContext : DbContext {
        
        public DbSet<Grad>? Gradovi {get; set;}

        public DbSet<MeteoroloskiPodaci>? Podaci {get; set;}

        public GradContext(DbContextOptions options) : base(options) {

        }

    }
}