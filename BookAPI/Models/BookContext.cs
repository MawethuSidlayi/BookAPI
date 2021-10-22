using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class BookContext: DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        // public DbSet<Subscription> Subscriptions { get; set; }



    }
}
