using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Library.Services;
using System.Web;
using Library.Models;
using Library.Entity;
using Library.Mappers;
using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Library.ViewModels;

namespace Library
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(Assembly.GetExecutingAssembly()); //Register MVC Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // регистрируем споставление типов
            builder.RegisterType<UserMapper>().As<IMapper<User, UserViewModel>>();
            builder.RegisterType<UserRepository>().As<IRepo<User>>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<BookMapper>().As<IMapper<Book, BookViewModel>>();
            builder.RegisterType<BookRepository>().As<IRepo<Book>>();
            builder.RegisterType<BookService>().As<IBookService>();

            builder.RegisterType<OrderMapper>().As<IMapper<Order, OrderViewModel>>();
            builder.RegisterType<OrderRepository>().As<IRepo<Order>>();
            builder.RegisterType<OrderService>().As<IOrderService>();


            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }


    }
}