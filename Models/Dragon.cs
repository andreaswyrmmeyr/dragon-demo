using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models;

public class Dragon 
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? ImgUrl { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required, Range(0, 5000)]
    public int Age { get; set; }
}