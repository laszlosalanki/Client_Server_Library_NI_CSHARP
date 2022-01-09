using Common;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ClientFrontEnd.Pages
{
#pragma warning disable LRT001
    public partial class AvailableBooksList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public AvailableBook[] AvailableBooks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AvailableBooks = await HttpClient.GetFromJsonAsync<AvailableBook[]>("availablebooks");
            await base.OnInitializedAsync();
        }
    }
}
