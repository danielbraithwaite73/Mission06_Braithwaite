using System.ComponentModel.DataAnnotations;

public class Application
{
    [Key]
    [Required]
    public int ApplicationId { get; set; }

    // Adding [Required] with a custom message ensures C# doesn't pass a null/empty string
    [Required(ErrorMessage = "Please enter a category.")]
    public string Category { get; set; }

    [Required(ErrorMessage = "The Movie Title is required.")]
    public string Title { get; set; }

    // Range prevents negative years.
    [Required(ErrorMessage = "Please enter a year.")]
    [Range(1888, 2026, ErrorMessage = "Please enter a valid year between 1888 and 2026.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Director is required.")]
    public string Director { get; set; }

    [Required(ErrorMessage = "Please select a rating.")]
    public string Rating { get; set; }

    // Booleans are inherently required (true/false), so no [Required] needed here.
    public bool Edited { get; set; }

    // Nullable string (string?) is correct for optional fields.
    public string? LentTo { get; set; }

    [MaxLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
    public string? Notes { get; set; }
}
