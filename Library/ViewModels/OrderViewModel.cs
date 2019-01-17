using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class OrderViewModel
    {
            [Required]
            public int Id { get; set; }
            [Required, Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a User")]
            [DisplayName("User")]
            public int UserId { get; set; }
            [Required]
            [DisplayName("Book"), Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a Book")]
            public int BookId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }

        public string BookName { get; set; }
        public string UserName { get; set; }

    }
}