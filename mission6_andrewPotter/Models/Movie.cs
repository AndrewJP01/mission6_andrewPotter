using System.ComponentModel.DataAnnotations;

namespace mission6_andrewPotter.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [Required]
        [Key]
        public int MovieId { get; set; }  // Primary Key (Required)

        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // CategoryId is the foreign key  // Nullable Foreign Key

        [Required]
        public string Title { get; set; } = string.Empty; // Required, but avoids NULL

        [Required]
        public int Year { get; set; } // Required (int cannot be NULL unless changed to `int?`)

        public string? Director { get; set; }  // Allow NULL

        public string? Rating { get; set; }  // Allow NULL

        [Required]
        public bool Edited { get; set; }  // Required, 0/1 (cannot be NULL)

        public string? LentTo { get; set; }  // Allow NULL

        [Required]
        public bool CopiedToPlex { get; set; }  // Required, 0/1 (cannot be NULL)

        public string? Notes { get; set; }  // Allow NULL

        // Navigation Property (Category can be NULL if no relation exists)
        public Category Category { get; set; }
    }
}
