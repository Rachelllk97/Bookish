using Bookish.Database;
using Microsoft.EntityFrameworkCore;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int Stock { get; set; }
    public int Available { get; set; }
    public List<MemberBook> MemberBooks { get; set; } = new List<MemberBook>();

}
