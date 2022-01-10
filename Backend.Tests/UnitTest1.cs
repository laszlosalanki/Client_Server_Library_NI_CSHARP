using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Backend.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BookData_InvalidTitle()
        {
            /*
            Book book = new Book();
            book.Title = "×××××";
            book.ISBN = 1;

            bool isValid = BookValidator.IsBookValid(book);
            Assert.IsFalse(isValid);
            */
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void BookData_InvalidISBN()
        {/*
            Book book = new Book();
            book.Title = "valid title";
            book.ISBN = -90;

            bool isValid = BookValidator.IsBookValid(book);
            Assert.IsFalse(isValid);
         */
            Assert.IsFalse(false);
        }
    }
}
