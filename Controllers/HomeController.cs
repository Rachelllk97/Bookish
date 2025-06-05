using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Database;
namespace Bookish.Controllers;



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BookishContext _context;

    public HomeController(ILogger<HomeController> logger, BookishContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }



public IActionResult Books()
{
        var books = _context.Books.ToList();

        Console.WriteLine("Books count: " + _context.Books.Count());

        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }

        return View(books);
}
     public IActionResult AddNewBook()
    {
        return View();
    }



 [HttpPost]
 [ValidateAntiForgeryToken]
  public ActionResult AddNewBook(Book book)
  {

    if (ModelState.IsValid)
        {
     _context.Books.Add(book);
     _context.SaveChanges();
    return RedirectToAction("AddNewBook"); 
    }
     return View(book);
    }

[HttpPost]
 [ValidateAntiForgeryToken]
    public ActionResult DeleteBook(int id)
    {
        Console.WriteLine($"Received ID: {id}");
        var book = _context.Books.Find(id);
        if (book != null)
        {
            Console.WriteLine("deleting");
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Books");
        }
    return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
