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
        var Results = context.Books.Where(s => s.Title == GetName()).ToList();
        foreach (Book result in Results)
        {
            Console.WriteLine(result.Title);
            Console.WriteLine(result.Author);
            Console.WriteLine($"There are {result.Stock} copies in total");
            Console.WriteLine($"There are {result.Available} copies available to borrow");
        }
        return Results;
    }

    public static string GetName()
    {
        return "Moby Dick";
    }
}
