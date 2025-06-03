using System.Collections.Immutable;
using System.ComponentModel;
using Bookish.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

public class Query
{
    public List<Book> TestQuery()
    {
        var context = new BookishContext();
        //dependancy injection^^
        var Titles = context.Books.ToList();
        // foreach (Book result in Titles)
        // {
        //     Console.WriteLine(result.Title);
        //     Console.WriteLine(result.Author);
        //     Console.WriteLine($"There are {result.Stock} copies in total");
        //     Console.WriteLine($"There are {result.Available} copies available to borrow");
        // }
        return List<Book> Titles;
    }
}
