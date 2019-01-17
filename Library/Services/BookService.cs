using Library.Entity;
using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using System.Collections.Generic;

namespace Library.Services
{

    public interface IBookService
    {

        BookViewModel GetBookById(int id);
        List<BookViewModel> GetAllBooks();
    }

    public class BookService: IBookService
    {

            private IRepo<Book> repoBook;
            private IMapper<Book, BookViewModel> bookMapper;


            public BookService(IRepo<Book> repoBook,  IMapper<Book, BookViewModel> bookMapper)
            {
                this.repoBook = repoBook;
                this.bookMapper = bookMapper;
            }

            public BookViewModel GetBookById(int id)
            {
                var book = repoBook.Get(id);
                return bookMapper.Map(book);
            }

            public List<BookViewModel> GetAllBooks()
            {
                var books = repoBook.GetAll();
                return bookMapper.Map(books);
            }


    }
}