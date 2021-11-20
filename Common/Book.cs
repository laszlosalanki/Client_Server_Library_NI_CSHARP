using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
#pragma warning disable LRT001
    public class Book
    {
        public long Id { get; set; } // the id of the book
        public string? Title { get; set; } // name of the book
        public bool IsBorrowed { get; set; } // is the given book borrowed?
        public string? Borrower { get; set; } // if so, who's borrowed it?
        public DateTime? BorrowDate { get; set; } // time of borrow
        public DateTime? ShouldReturn { get; set; } // when should he/she retrun the given book?
    }
}
