using Library.Entity;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Mappers
{
    public class BookMapper : IMapper<Book, BookViewModel>
    {
        public BookMapper()
        {
        }

        public BookViewModel Map(Book book)
        {
            BookViewModel model = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Genre = book.Genre,
                ISBN = book.ISBN,
                Year = book.Year

            };

            return model;
        }

        public Book Map(BookViewModel model)
        {

            Book user = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Author = model.Author,
                ISBN = model.ISBN,
                Genre = model.Genre,
                Year = model.Year
            };
        
            return user;
        }

        public Book Map(BookViewModel model, Book book)
        {
            return new Book();
        }

        public List<BookViewModel> Map(List<Book> entity)
        {
            List<BookViewModel> models = new List<BookViewModel>();
            foreach (var item in entity)
            {
                models.Add(Map(item));
            }

            return models;
        }

        public List<Book> Map(List<BookViewModel> model)
        {
            List<Book> books = new List<Book>();
            foreach (var item in model)
            {
                books.Add(Map(item));
            }

            return books;
        }
    }
}