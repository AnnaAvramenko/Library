using Library.Entity;
using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Library.Services
{

    public interface IOrderService
    {

        OrderViewModel GetOrderById(int id);
        List<OrderViewModel> GetAllOrders();
        void AddOrder(OrderViewModel order);
    }

    public class OrderService : IOrderService
    {

            private IRepo<Order> repoOrder;
            private IMapper<Order, OrderViewModel> orderMapper;


            public OrderService(IRepo<Order> repoOrder,  IMapper<Order, OrderViewModel> orderMapper)
            {
                this.repoOrder = repoOrder;
                this.orderMapper = orderMapper;
            }

            public OrderViewModel GetOrderById(int id)
            {
                var order = repoOrder.Get(id);
                return orderMapper.Map(order);
            }

            public List<OrderViewModel> GetAllOrders()
            {
                var orders = repoOrder.GetAll();
                return orderMapper.Map(orders);
            }

            public void AddOrder(OrderViewModel model)
            {
                 var order = orderMapper.Map(model);
                 repoOrder.Create(order);
            }


    }
}