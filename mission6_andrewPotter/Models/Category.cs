using System.ComponentModel.DataAnnotations;

namespace mission6_andrewPotter.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }  // Primary Key

        [Required]
        public string CategoryName { get; set; }

        // Navigation Property (One Category can have many Movies)
        public List<Movie> Movies { get; set; }
    }
}