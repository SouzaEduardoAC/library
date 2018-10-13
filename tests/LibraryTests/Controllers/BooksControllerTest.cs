using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using library.Controllers;
using library.Domains.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace LibraryTests.Controllers
{
    public class BooksControllerTest
    {
        private BooksController _controller;
        private IBookService _service;

        public BooksControllerTest()
        {
            _service = new BookServiceMock();
            _controller = new BooksController(_service);
        }

        [Fact]
        public void Add_Book()
        {
            var bookDTO = new BookDTO()
            {
                Title = "Head First Agile",
                Author = "Andrew Stellman, Jennifer Greene",
                ReleaseDate = DateTime.Parse("2017-09-20")
            };
            var result = _controller.Post(bookDTO) as CreatedAtRouteResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void Get_Books()
        {
            var result = _controller.Get();
            Assert.Equal(3, result.Value.Count);
        }

        [Fact]
        public void Get_One()
        {
            var books = _controller.Get().Value;
            var result = _controller.Get(books.First().ID);
            Assert.Equal("Head First Agile", result.Value.Title);
            Assert.Equal("Andrew Stellman, Jennifer Greene", result.Value.Author);
            Assert.Equal(DateTime.Parse("2017-09-10"), result.Value.ReleaseDate);
        }

        [Fact]
        public void Remove()
        {
            var books = _controller.Get().Value;
            var removedBook = books.First();
            _controller.Delete(books.First().ID);
            var result = _controller.Get().Value;
            Assert.DoesNotContain(removedBook, result);
        }
    }
}