using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
#pragma warning disable LRT001
    public class AvailableBook
    {
        public long ISBN { get; set; } // the id of the book
        public string Title { get; set; } // name of the book
        public string? Authors { get; set; } // the author of the book
        public string? Publisher { get; set; } // name of the publisher
        public DateTime? ReleaseDate { get; set; } // release date of the book

        public AvailableBook() { }
        public AvailableBook(long iSBN, string title, string? authors, string? publisher, DateTime? releaseDate)
        {
            ISBN = iSBN;
            Title = title;
            Authors = authors;
            Publisher = publisher;
            ReleaseDate = releaseDate;
        }
    }
}
