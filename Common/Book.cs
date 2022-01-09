using System.ComponentModel.DataAnnotations;

namespace Common
{
#pragma warning disable LRT001
    public class Book
    {
        [Key] public long ISBN { get; set; } // the id of the book
        public string Title { get; set; } // name of the book
        public string? Authors { get; set; } // the author of the book
        public string? Publisher { get; set; } // name of the publisher
        public DateTime? ReleaseDate { get; set; } // release date of the book
        public string? BorrowerFirstName { get; set; } // first name of the borrower
        public string? BorrowerLastName { get; set; } // last name of the borrower
        public DateTime? BorrowDate { get; set; } // time of borrow
        public DateTime? ShouldReturn { get; set; } // when should he/she retrun the given book?

        public Book() { }
        public Book(long iSBN, string title, string? authors, string? publisher, DateTime? releaseDate, string? borrowerFirstName, string? borrowerLastName, DateTime? borrowDate, DateTime? shouldReturn)
        {
            ISBN = iSBN;
            Title = title;
            Authors = authors;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            BorrowerFirstName = borrowerFirstName;
            BorrowerLastName = borrowerLastName;
            BorrowDate = borrowDate;
            ShouldReturn = shouldReturn;
        }
    }
}
