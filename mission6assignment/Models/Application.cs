using Mission06_Braithwaite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Application
{
    [Key]
    [Required]
    public int MovieId { get; set; }

    [ForeignKey("CategoryId")] // Connections point to the Category table.
    public int? CategoryId { get; set; }

    public Category? Category { get; set; }

    // Adding [Required] with a custom message ensures C# doesn't pass a null/empty string.
    [Required(ErrorMessage = "The Movie Title is required.")]
    public string Title { get; set; }

    // Range prevents unrealistic years.
    [Required(ErrorMessage = "Please enter a year.")]
    [Range(1888, 2026, ErrorMessage = "Please enter a valid year between 1888 and 2026.")]
    public int Year { get; set; }

    public string? Director { get; set; }

    public string? Rating { get; set; }

    // Booleans are inherently required (true/false), so no [Required] needed here.
    public bool Edited { get; set; }

    public string? LentTo { get; set; }
    
    public bool CopiedToPlex { get; set; }

    [MaxLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
    public string? Notes { get; set; }
}
