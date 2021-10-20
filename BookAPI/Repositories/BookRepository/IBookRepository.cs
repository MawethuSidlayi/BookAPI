using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories.BookRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        Task Update(Book book);
    }
}
