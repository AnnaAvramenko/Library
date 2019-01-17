
using Dapper;
using Library.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Models
{

    public class BookRepository : IRepo<Book>
    {
        string connectionString = null;
        public BookRepository()
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
        }
        public List<Book> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT * FROM Books").ToList();
            }
        }

        public Book Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT * FROM Books WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Book user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Books (Name, Authors, ISBN, Genre, Year) VALUES(@Name, @Authors, @ISBN, @Genre, @Year)";
                db.Execute(sqlQuery, user);
            }
        }

        public void Update(Book user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Books SET Name = @Name, Author = @Author, ISBN = @ISBN, Genre = @Genre, Year = @Year WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Books WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}