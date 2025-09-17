using Microsoft.EntityFrameworkCore;
using Dal_Book;
using System;
using System.Collections.Generic;


namespace Dal_Book
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }

}
