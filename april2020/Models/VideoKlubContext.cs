using Microsoft.EntityFrameworkCore;

namespace Models {

    public class VideoKlubContext : DbContext {

        public DbSet<VideoKlub> VideoKlubovi {get; set;}

        public DbSet<Polica> Police {get; set;}

        public VideoKlubContext(DbContextOptions options) : base(options) {
            
        }
    }
}