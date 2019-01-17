using Library.Services;
using Library.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "User Page";

            List<UserViewModel> model = new List<UserViewModel>();
            model = _userService.GetAllUsers();

            return View(model);
        }
    }
}
