using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers;

[ApiController ]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly List<Book> books = new List<Book>()
    {
        new Book
        {
            Id = 1,
            Title = "Clean Code",
            Author = "Robert Martin",
            Price = 25.5m,
            Rating = 5
        },

        new Book
        {
            Id = 2,
            Title = "The Pragmatic Programmer",
            Author = "David Thomas",
            Price = 30m,
            Rating = 5
        },

        new Book
        {
            Id = 3,
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Price = 40m,
            Rating = 4
        }

    };
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        if (books.Any(b => b.Id == book.Id))
        {
            
        }
        books.Add(book);

        return CreatedAtAction(nameof(Get),
            new { id = book.Id },
            book);
    }
}