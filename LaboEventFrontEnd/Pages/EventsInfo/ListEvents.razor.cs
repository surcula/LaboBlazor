

using BlazorBootstrap;
using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LaboEventFrontEnd.Pages.EventsInfo
{
    public partial class ListEvents
    {
        public List<Events> ListEvent { get; set; } 
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public ToastService ToastService { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ListEvent = new List<Events>();
            try
            {                
                HttpResponseMessage response = await Client.GetAsync("event");
                if (response.IsSuccessStatusCode)
                {
                    ListEvent = await response.Content.ReadFromJsonAsync<List<Events>>();
                }
                else
                {
                    ToastService.Notify(new ToastMessage(ToastType.Warning, "Une erreur est survenue, veuillez réessayer plus tard ou contacter l'administrateur."));
                }
            }
            catch (HttpRequestException ex)
            {
                ToastService.Notify(new ToastMessage(ToastType.Warning, "Une erreur est surevenue, veuillez réessayer plus tard ou contacter l'admin."));
            }
        }

        public void DeleteConfirmation(int id)
        {
            Nav.NavigateTo("/DeleteEventById/" + id);
        }

    }
}
