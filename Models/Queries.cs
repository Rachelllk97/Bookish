using System.Collections.Immutable;
using System.ComponentModel;
using Bookish.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;


public class Query
{
    public List<Book> TestQuery()
    {
        using var context = new BookishContext(); 
        return context.Books.ToList();
    }

}
