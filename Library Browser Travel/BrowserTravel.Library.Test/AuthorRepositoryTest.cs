using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BrowserTravel.Library.Infraestructure.Data;
using BrowserTravel.Library.Entities.Models;
using System;
using BrowserTravel.Library.Repository.Repositories;
using System.Reflection.Metadata;
using BrowserTravel.Library.Repository.Interfaces;
using BrowserTravel.Library.Services.Areas.Library;
using BrowserTravel.Library.Entities.Dto.Library;
using System.Linq;

namespace BrowserTravel.Library.Test
{
    [TestFixture]
    public class AuthorRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void GetById_Author_ReturnCorrect(int id)
        {
            // Arrange
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock
                .Setup(r => r.Get(id))
                .Returns(Task.FromResult(new Author { Name = "Nombre", Id = id, LastName = "Apellido" }));

            var authorService = new AuthorService(authorRepositoryMock.Object);

            // Act
            var author = authorService.Get(id);

            // Assert
            authorRepositoryMock.Verify(r => r.Get(id));
            Assert.IsNotNull(author.Result);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void GetById_Author_ReturnNull(int id)
        {
            // Arrange
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock
                .Setup(r => r.Get(id))
                .Returns(Task.FromResult(new Author { Name = "Nombre", Id = id, LastName = "Apellido" }));

            var authorService = new AuthorService(authorRepositoryMock.Object);

            // Act
            var author = authorService.Get(1);

            // Assert
            authorRepositoryMock.Verify(r => r.Get(1));
            Assert.IsNull(author.Result);
        }

        [Test]
        public void GetAll_Author_ReturnNull()
        {
            // Arrange
            var authosrResponse = new List<Author>() {
                    new Author { Name = "Nombre", Id = 1, LastName = "Apellido" },
                    new Author { Name = "Nombre 1", Id = 2, LastName = "Apellido 1" }
                }.AsQueryable();

            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock
                .Setup(r => r.GetAll())
                .Returns(authosrResponse);

            var authorService = new AuthorService(authorRepositoryMock.Object);

            // Act
            var authors = authorService.GetAll();

            // Assert
            authorRepositoryMock.Verify(r => r.GetAll());
            Assert.True(authors.Result.Count > 0);
        }

        [Test]
        [TestCase(1, "Nombre 1", "Apellido 1")]
        [TestCase(2, "Nombre 2", "Apellido 2")]
        public void Add_Author_ReturnCorrect(int id, string name, string lastName)
        {
            // Arrange
            var author = new Author
            {
                Id = id,
                LastName = lastName,
                Name = name
            };

            var authorRepositoryMock = new Mock<IAuthorRepository>();
            authorRepositoryMock
                .Setup(r => r.Add(author))
                .Returns(Task.FromResult(author));

            var authorService = new AuthorService(authorRepositoryMock.Object);

            // Act
            var authorResponse = authorService.Add(new AuthorDto
            {
                Name = name,
                LastName = lastName
            });

            // Assert
            authorRepositoryMock.Verify(r => r.Add(author));
            Assert.IsNotNull(authorResponse.Result);
        }
    }
}