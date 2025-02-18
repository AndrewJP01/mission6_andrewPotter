using Microsoft.EntityFrameworkCore;

namespace mission6_andrewPotter.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() { } // Default constructor (needed for migrations)
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) // Constructor
        { 
        }

        // this gets both of our models set up for each table
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
