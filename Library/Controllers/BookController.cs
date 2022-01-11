using System;
using Common;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/books/")]
public class BookController : Controller
{
    private IBookRepository _bookRepo { get; set; }
    public BookController(IBookRepository bookRepo)
    {
        this._bookRepo = bookRepo;
    }

    private Book DummyData()
    {
        var r = new Random().Next(0, 9000);
        return new Book((long)r, "asd", "asd", "mr. asd", DateTime.Now, null, null, null, null);
    }

    [HttpGet] [Route("{isbn}")]
    public ActionResult<Book?> GetBook([FromRoute] long isbn)
    {
        Book? result = this._bookRepo.GetBook(isbn);
        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest("Requested book was not found.");
        }
    }

    [HttpGet] [Route("availableAll")]
    public ActionResult<Book[]> GetAvailableBooks()
    {
        try
        {
            return Ok(this._bookRepo.GetAvailableBooks());
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpGet] [Route("borrowedAll")]
    public ActionResult<Book[]> GetBorrowedBooks()
    {
        try
        {
            return Ok(this._bookRepo.GetBorrowedBooks());
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpGet] [Route("borrowedBy/{name}")]
    public ActionResult<Book[]> GetBorrowedBooksBy([FromRoute] string name)
    {
        try
        {
            return Ok(this._bookRepo.GetBorrowedBooksBy(name));
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpGet] [Route("isbn/{number}")]
    public ActionResult<bool> IsAvailableISBN([FromRoute] long number)
    {
        return Ok(this._bookRepo.IsAvailableISBN(number));
    }

    [HttpPost] [Route("add")]
    public ActionResult<Book> AddBook([FromBody] Book bookToAdd)
    {
        try
        {
            return Ok(this._bookRepo.AddNewBook(bookToAdd));
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpDelete] [Route("delete/{isbn}")]
    public ActionResult DeleteBook([FromRoute] long isbn)
    {
        try
        {
            var deleted = this._bookRepo.DeleteBook(isbn);

            var response = "Deleted book with ISBN number: " + isbn;
            if (!deleted)
            {
                response = "Deletion operation was unsuccessful.";
            }
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpDelete] [Route("deleteBooks")]
    public ActionResult DeleteBooks([FromBody] long[] isbn)
    {
        this._bookRepo.DeleteBooks(isbn);
        return Ok("Deletion operation finished.");
    }

    [HttpPut] [Route("update")]
    public ActionResult<Book> UpdateBook([FromBody] Book bookToUpdate)
    {
        try
        {
            return Ok(this._bookRepo.UpdateBook(bookToUpdate));
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpPut] [Route("returnBooks")]
    public ActionResult ReturnBooks([FromBody] long[] isbnNumbers)
    {
        try
        {
            this._bookRepo.ReturnBooks(isbnNumbers);
            return Ok("Books returned successfully.");
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

    [HttpPut] [Route("lendBooks")]
    public ActionResult LendBooks([FromBody] Book[] booksToLend)
    {
        try
        {
            this._bookRepo.LendBooks(booksToLend);
            return Ok("Books lent successfully.");
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }
}