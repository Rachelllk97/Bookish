using Bookish.Database;
using Microsoft.EntityFrameworkCore;

public class Member
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<MemberBook>? MemberBooks { get; set; } = new List<MemberBook>();
}
