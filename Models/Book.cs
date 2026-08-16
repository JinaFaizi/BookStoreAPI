using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models;

public class Book
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string? Author { get; set; }
    
    [Range(0.01, double.MaxValue)]
    public decimal? Price { get; set; }
    
    [Range(1, 5)]
    public int Rating { get; set; }
    
}