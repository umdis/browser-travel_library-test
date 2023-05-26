using BrowserTravel.Library.Common.Cryptography;
using BrowserTravel.Library.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BrowserTravel.Library.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Editorial> Editorials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Name = "Admin" },
                new Rol { Id = 2, Name = "Author" });

            var salt = HiddenSecret.GenerateSalt();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "admin@email.com",
                Name = "Admin user",
                Salt = salt,
                SaltedAndHashedPassword = HiddenSecret.Hash("12345678", salt),
                CreateAt = DateTime.Now,
                IdRol = 1
            });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Franz", LastName = "Kafka" },
                new Author { Id = 2, Name = "Zygmunt", LastName = "Bauman" });

            modelBuilder.Entity<Editorial>().HasData(
                new Editorial { Id = 1, Name = "Sol naciente", Site = "Cali" },
                new Editorial { Id = 2, Name = "Visión objetiva", Site = "Barranquilla" });

            modelBuilder.Entity<Book>().HasData(
                new Book { IdEditorial = 1, Id = 1, ISBN = "9780435910105", NumberPages = 546, Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", Title = "African Folktales" },
                new Book { IdEditorial = 2, Id = 2, ISBN = "9781906523374", NumberPages = 200, Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", Title = "984 by George Orwell" },
                new Book { IdEditorial = 2, Id = 3, ISBN = "9780394721170", NumberPages = 105, Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", Title = "The Lord of the Rings by J.R.R. Tolkien" },
                new Book { IdEditorial = 1, Id = 4, ISBN = "9780813190761", NumberPages = 97, Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", Title = "The Kite Runner by Khaled Hosseini" });

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorBook",
                    b => b.HasOne<Book>().WithMany().HasForeignKey("BooksId"),
                    a => a.HasOne<Author>().WithMany().HasForeignKey("AuthorsId"),
                    je =>
                    {
                        je.HasKey("BooksId", "AuthorsId");
                        je.HasData(
                            new { BooksId = 1, AuthorsId = 1 },
                            new { BooksId = 2, AuthorsId = 1 },
                            new { BooksId = 3, AuthorsId = 1 },
                            new { BooksId = 4, AuthorsId = 2 });
                    });
        }
    }
}
