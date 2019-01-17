using Library.Services;
using Library.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderService;
        public IUserService _userService;
        public IBookService _bookService;

        public OrderController(IOrderService orderService, IUserService userService, IBookService bookService)
        {
            _orderService = orderService;
            _bookService = bookService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Order Page";
            ViewBag.Users = _userService.GetAllUsers();
            ViewBag.Books = _bookService.GetAllBooks();

            List<OrderViewModel> model = new List<OrderViewModel>();
            model = _orderService.GetAllOrders();

            return View(model);
        }

        public ActionResult Add()
        {
            OrderViewModel model = new OrderViewModel();
            ViewBag.Users = _userService.GetAllUsers();
            ViewBag.Books = _bookService.GetAllBooks();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(OrderViewModel data)
        {

            _orderService.AddOrder(data);
            return RedirectToAction("Index");
        }

    }
}
