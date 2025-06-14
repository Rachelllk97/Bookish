using Bookish.Database;
using Microsoft.EntityFrameworkCore;

public class MemberBook
{
    public int Id { get; set;}
    public int MemberId { get; set; }
    public required Member Member { get; set; }

    public int BookId { get; set; }
    public required Book Book { get; set; }
    public DateTime BorrowedDate { get; set; }
}
