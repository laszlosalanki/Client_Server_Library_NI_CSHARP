using Common;
using Microsoft.AspNetCore.Mvc;

[Route("api/")]
public class BookController : Controller
{
    private IBookRepository _bookRepo { get; set; }

    public BookController(IBookRepository bookRepo)
    {
        this._bookRepo = bookRepo;
    }

    [HttpGet]
    [Route("availableBooks")]
    public ActionResult<List<Book>> GetAvailableBooks()
    {
        try
        {
            return Ok(this._bookRepo.getAvailableBooks());
        }
        catch (Exception)
        {
            return BadRequest("Internal server error.");
        }
    }

}
