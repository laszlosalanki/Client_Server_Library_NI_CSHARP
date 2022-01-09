using Microsoft.AspNetCore.Components;

namespace ClientFrontEnd.Pages
{
#pragma warning disable LRT001
    public partial class AvailableBookDetails
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public long AvailableISBN{ get; set; }
    }
}
