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
            "Borrower last name"
        };

        // Let 'Title' be the default filter for searching
        public static int DEFAULT_FILTER_INDEX = 1;
        public static string DEFAULT_FILTER_AVAILABLE = AVAILABLE_FILTER_OPTIONS[DEFAULT_FILTER_INDEX];
        public static string DEFAULT_FILTER_BORROWED = BORROWED_FILTER_OPTIONS[DEFAULT_FILTER_INDEX];
    }
}
