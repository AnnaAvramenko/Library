using System;

namespace Library.Entity
{
    public class Order
    {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int BookId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }

            public Book Book { get; set; }
            public User User { get; set; }
    } 
}