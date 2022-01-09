using Common;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ClientFrontEnd.Pages
{
#pragma warning disable LRT001
    public partial class AvailableBookDetails
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public long AvailableISBN{ get; set; }

        public Book Book{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await HttpClient.GetFromJsonAsync<Book>($"availablebook/{AvailableISBN}");
            await base.OnInitializedAsync();
        }
    }
}
