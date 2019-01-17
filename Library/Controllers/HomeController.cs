using Library.Services;
using Library.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IBookService _bookService;


        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Book Page";

            List<BookViewModel> model = new List<BookViewModel>();
            model = _bookService.GetAllBooks();

            return View(model);
        }
    }
}
