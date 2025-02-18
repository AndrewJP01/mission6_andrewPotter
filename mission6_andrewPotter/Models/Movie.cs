using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission6_andrewPotter.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int MovieId { get; set; }  // Primary Key (Required)

        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // CategoryId is the foreign key

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty; // Required, but avoids NULL

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; } // Required (int cannot be NULL unless changed to `int?`)

        public string? Director { get; set; }  // Allow NULL

        public string? Rating { get; set; }  // Allow NULL

        [Required(ErrorMessage = "Edited field is required.")]
        public bool Edited { get; set; }  // Required, 0/1 (cannot be NULL)

        public string? LentTo { get; set; }  // Allow NULL

        [Required(ErrorMessage = "CopiedToPlex field is required.")]
        public bool CopiedToPlex { get; set; }  // Required, 0/1 (cannot be NULL)

        public string? Notes { get; set; }  // Allow NULL

        // Navigation Property (Category can be NULL if no relation exists)
        public required Category Category { get; set; }
    }
}
