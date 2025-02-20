using System.ComponentModel.DataAnnotations;

namespace HomeworkASP2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author name cannot be longer than 100 characters")]
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;

        [Required(ErrorMessage = "Language is required")]
        [StringLength(50, ErrorMessage = "Language name cannot be longer than 50 characters")]
        public string Language { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(100, ErrorMessage = "Genre cannot be longer than 100 characters")]
        public string Genre { get; set; } = string.Empty;

        [Range(1, 5000, ErrorMessage = "Pages must be between 1 and 5000")]
        public int Pages { get; set; }
    }
}
