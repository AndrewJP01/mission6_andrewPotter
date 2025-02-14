using System.ComponentModel.DataAnnotations;

namespace mission6_andrewPotter.Models
{

using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        [Key]  // Primary Key
        public int MovieID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        public string Description { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }  //  bool (true, false, or null)

        public string? LentTo { get; set; }  // Nullable string (optional)

        [MaxLength(25)] // Ensures Notes cannot exceed 25 characters
        public string? Notes { get; set; }
    }

}
