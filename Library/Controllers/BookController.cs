using Common;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet] [Route("available")]
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

    [HttpGet] [Route("borrowed")]
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

    [HttpPut] [Route("add")]
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

    [HttpGet] [Route("delete/{isbn}")]
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

    [HttpPost] [Route("update")]
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

    [HttpPost] [Route("return")]
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

    [HttpPost] [Route("lend")]
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
