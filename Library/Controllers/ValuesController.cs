using Library.Services;
using Library.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Library.Controllers
{
    public class ValuesController : ApiController
    {
        public IUserService _userService;
        public IBookService _bookService;
        public IOrderService _orderService;

        public ValuesController(IUserService userService, IBookService bookService, IOrderService orderService)
        {
            _userService = userService;
            _bookService = bookService;
            _orderService = orderService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public List<UserViewModel> GetUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        public List<BookViewModel> GetBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet]
        public List<OrderViewModel> GetOrders()
        {
            return _orderService.GetAllOrders();
        }
        
        [HttpPost]
        public bool SaveOrders([FromBody]OrderViewModel data)
        {
            try
            {
                if (data != null)
                {
                    _orderService.AddOrder(data);
                    return true;
                }
              
            }
            catch
            {
            }
                return false;
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
