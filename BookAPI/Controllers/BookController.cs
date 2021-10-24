using BookAPI.Domain.Interfaces;
using BookAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBookRepository bookRepository;
        private readonly IRepository<BookSubscriptions> repository;


        public BookController(IBookRepository bookRepository, IRepository<BookSubscriptions> repository, UserManager<IdentityUser> userManager)
        {
            this.bookRepository = bookRepository;
            this.repository = repository;
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("")]
        public async Task  AddBook([FromBody] Book book) => await bookRepository.Insert(book);
        
        [Authorize]
        [HttpPost]
        [Route("/Subscribe")]
        public async Task SubscribeToBook([FromBody] BookSubscriptions book)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            book.User_Id = userId;
            await repository.Insert(book);
        }


        [HttpGet]
        [Route("")]
        public async Task< IEnumerable<Book>> GetAllBooks() => await bookRepository.GetAll();
        
        [Authorize]
        [HttpGet]
        [Route("{bookId}")]
        public async Task<Book> GetBookById(int bookId) => await bookRepository.GetById(bookId);


        [HttpDelete]
        [Route("{bookId}")]
        public async Task DeleteId(int bookId) => await bookRepository.Delete(bookId);



    }
}
