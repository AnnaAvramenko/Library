
using Dapper;
using Library.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Models
{
    public class OrderRepository : IRepo<Order>
    {
        string connectionString = null;
        public OrderRepository()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];

        }
        public List<Order> GetAll()
        {
            string query = "SELECT orders.StartDate, orders.EndDate,books.Id,  books.Name, books.Author,  users.Id,users.FirstName, users.LastName FROM Orders as orders Join Books as books ON orders.BookId = books.Id Join Users as users ON orders.UserId = users.Id";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Order, Book, User, Order>(query,
                      (order, book, user) => {
                          order.User = user;
                          order.Book = book;
                          return order;
                      }).ToList();

            }
        }

        public Order Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Order>("SELECT * FROM Orders WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Order order)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Orders (UserId, BookId, StartDate, EndDate) VALUES(@UserId, @BookId, @StartDate, @EndDate)";
                db.Execute(sqlQuery, order);

            }
        }

        public void Update(Order order)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Orders SET UserId = @UserId, BookId = @BookId, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @Id";
                db.Execute(sqlQuery, order);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Orders WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}