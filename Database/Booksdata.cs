namespace Bookish.Database;

public class BooksData()
{
    public void AddSampleBook()
    {
        var context = new BookishContext();
        {
            var book = new Book()
            {
                Title = "Moby Dick",
                Author = "Herman Melville",
                Stock = 10,
                Available = 10,
            };

            context.Books.Add(book);

            context.SaveChanges();
        }
        ;
    }
}
