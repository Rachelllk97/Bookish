using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Database
{
    public class BookishContext : DbContext
    {
        // Put all the tables you want in your database here
        public DbSet<Book> Books { get; set; }   
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberBook> MemberBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(
                @"Server=localhost;Port=5432;Database=bookish;UserId=bookish;Password=bookish;"
            );
        }
    }
}
