
using Dapper;
using Library.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Models
{

    public class UserRepository : IRepo<User>
    {
        string connectionString = null;
        public UserRepository()
        {
                      connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];

        }
        public List<User> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (FirstName, LastName, PhoneNumber) VALUES(@FirstName, @LastName, @PhoneNumber)";
                db.Execute(sqlQuery, user);

            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}