using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    #pragma warning disable LRT001 // There is only one restricted namespace
    public static class Constants
    {
        // List of the available filters for searching
        public static List<string> AVAILABLE_FILTER_OPTIONS = new List<string>()
        {
            "ISBN",
            "Title",
            "Authors",
            "Publisher"
        };

        // List of the borrowed filters for searching
        public static List<string> BORROWED_FILTER_OPTIONS = new List<string>()
        {
            "ISBN",
            "Title",
            "Authors",
            "Publisher",
            "Borrower first name",
            "Borrower last name",
            "Date of borrow"
        };

        // Let 'Title' be the default filter for searching
        public static int DEFAULT_FILTER_INDEX = 1;
        public static string DEFAULT_FILTER = AVAILABLE_FILTER_OPTIONS[DEFAULT_FILTER_INDEX];

        // Temporal data for demonstration
        public static List<AvailableBook> TEMPORAL_DATA_AVAILABLE = new List<AvailableBook>()
        {
            new AvailableBook(9780590032490, "The Witches", "Roald Dahl", "Scholastic", DateTime.Now),
            new AvailableBook(9780553571332, "The Giver", "Lois Lowry", "Bantam Books for Young Readers", DateTime.Now),
            new AvailableBook(9780370332284, "Wonder", "R. J. Palaciov", "Bodley Head", DateTime.Now),
            new AvailableBook(9780765377067, "The Three-Body Problem", "Cixin Liu", "Tor Books", DateTime.Now)
        };

        public static List<Book> TEMPORAL_DATA_BORROWED = new List<Book>()
        {
            new Book(9780439064873, "Harry Potter and the Chamber of Secrets", "J. K. Rowling", "Scholastic", DateTime.Now, "Peter", "Parker", DateTime.Today, DateTime.Today),
            new Book(9780671671136, "Treasure", "Clive Cussler", "Pocket Books", DateTime.Now, "Jack", "Pocket", DateTime.Today, DateTime.Today),
            new Book(9781416936466, "Hatchet", "Gary Paulsen", "Simon Pulse", DateTime.Now, "Jack", "Pocket", DateTime.Today, DateTime.Today),
            new Book(9780553573428, "A storm of swords", "George R. R. Martin", "Bantam Books", DateTime.Now, "Kim", "Kimberly", DateTime.Today, DateTime.Today),
            new Book(9780060731328, "Freakonomics", "Steven D. Levitt, Stephen J. Dubner", "William Morrow", DateTime.Now, "Kim", "Kimberly", DateTime.Today, DateTime.Today)
        };
    }
}
