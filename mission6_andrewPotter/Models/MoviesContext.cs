using Microsoft.EntityFrameworkCore;

namespace mission6_andrewPotter.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() { } // Default constructor (needed for migrations)
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) // Constructor
        { 
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
