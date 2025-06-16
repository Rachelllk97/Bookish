using System.Diagnostics;
using Bookish.Database;
using Bookish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        books.Sort((x, y) => x.Title.CompareTo(y.Title));

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

    [HttpGet]
    public IActionResult EditBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditBook(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Books");
        }
        return View(book);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    [HttpGet]
    public IActionResult Members()
    {
        var members = _context.Members
          .Include(m => m.MemberBooks)
          .ThenInclude(mb => mb.Book)
          .ToList();

        Console.WriteLine("Members count: " + _context.Books.Count());

        foreach (var member in members)
        {
            Console.WriteLine($"Name: {member.Name}");
        }

        return View(members);
    }

[HttpGet]
public IActionResult EditMember(int id)
{
    var member = _context.Members
        .Include(m => m.MemberBooks)
        .ThenInclude(mb => mb.Book)
        .FirstOrDefault(m => m.Id == id);

    if (member == null)
    {
        return NotFound();
    }

    ViewBag.Books = _context.Books.ToList(); 
    return View(member);
}


 [HttpPost]
public IActionResult EditMember(Member member, int? SelectedBookId)
{
    if (ModelState.IsValid)
    {
        var existingMember = _context.Members
            .Include(m => m.MemberBooks)
            .FirstOrDefault(m => m.Id == member.Id);

        if (existingMember == null)
        {
            return NotFound();
        }

        existingMember.Name = member.Name;

        if (SelectedBookId.HasValue)
        {
            var book = _context.Books.Find(SelectedBookId.Value);
            if (book != null)
            {
                var newMemberBook = new MemberBook
                {
                    MemberId = existingMember.Id,
                    Member = existingMember,
                    BookId = book.Id,
                    Book = book,
                    BorrowedDate = DateTime.UtcNow
                };
                _context.MemberBooks.Add(newMemberBook);
            }
        }

        _context.SaveChanges();
        return RedirectToAction("Members");
    }

    ViewBag.Books = _context.Books.ToList(); 
    return View(member);
}



    [HttpPost]
    public ActionResult DeleteMember(int id)
    {
        Console.WriteLine("the id is", id);
        var member = _context.Members.Find(id);

        //  .Include(m => m.MemberBooks)
        //  .FirstOrDefault(m => m.Id == id);

        // if (member == null)
        // {
        //     return NotFound();
        // }

        // _context.MemberBooks.RemoveRange(member.MemberBooks);

        _context.Members.Remove(member);
        _context.SaveChanges();

     return View();
        // return RedirectToAction("Members");
    }


}