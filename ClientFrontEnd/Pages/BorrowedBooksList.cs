using Common;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ClientFrontEnd.Pages
{
#pragma warning disable LRT001
    public partial class BorrowedBooksList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Book[] BorrowedBooks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // TODO: client should see the related books only
            BorrowedBooks = await HttpClient.GetFromJsonAsync<Book[]>("books/borrowed");
            await base.OnInitializedAsync();
        }
    }
}
