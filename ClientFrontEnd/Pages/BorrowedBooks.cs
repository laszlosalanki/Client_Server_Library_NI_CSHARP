using Common;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ClientFrontEnd.Pages
{
#pragma warning disable LRT001
    public partial class BorrowedBooks
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public string BorrowerName { get; set; }

        public Book[] Books { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Books = await HttpClient.GetFromJsonAsync<Book[]>($"books/borrowedBy/{BorrowerName}");
            await base.OnInitializedAsync();
        }
    }
}
