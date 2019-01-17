using Library.Entity;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Mappers
{
    public class OrderMapper : IMapper<Order, OrderViewModel>
    {
        public OrderMapper()
        {
        }

        public OrderViewModel Map(Order order)
        {
            OrderViewModel model = new OrderViewModel
            {
                Id = order.Id,
                UserId = order.UserId,
                BookId = order.BookId,
                StartDate = order.StartDate,
                EndDate = order.EndDate,
                BookName = order.Book.Name,
                UserName = $"{order.User.FirstName} {order.User.LastName}",

            };

            return model;
        }

        public Order Map(OrderViewModel model)
        {

            Order order = new Order()
            {
                Id = model.Id,
                UserId = model.UserId,
                BookId = model.BookId,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
        
            return order;
        }

        public Order Map(OrderViewModel model, Order order)
        {
            return new Order();
        }

        public List<OrderViewModel> Map(List<Order> entity)
        {
            List<OrderViewModel> models = new List<OrderViewModel>();
            foreach (var item in entity)
            {
                models.Add(Map(item));
            }

            return models;
        }

        public List<Order> Map(List<OrderViewModel> model)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in model)
            {
                orders.Add(Map(item));
            }

            return orders;
        }
    }
}