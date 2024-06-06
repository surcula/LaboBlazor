using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace LaboEventFrontEnd.Pages.EventsInfo
{
    public partial  class DeleteEvent
    {
        

        [Parameter]
        public int EventId { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }
        [Inject]
        public ToastService ToastService { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public IJSRuntime jSRuntime { get; set; }

        protected override void OnInitialized()
        {
            Console.WriteLine("test54");
        }


        private async Task ConfirmDelete()
        {
            string token = await jSRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await HttpClient.DeleteAsync($"Event/" + EventId);
            if (response.IsSuccessStatusCode)
            {
                
                ToastService.Notify(new ToastMessage(ToastType.Success,"Evènement supprimé"));
                Nav.NavigateTo("/eventsList");
            }
            else
            {
                ToastService.Notify(new ToastMessage(ToastType.Warning, "Une erreur est survenue, veuillez réessayer plus tard ou contacter l'administrateur."));
            }
        }

        private async Task CancelDelete()
        {
           
            ToastService.Notify(new ToastMessage(ToastType.Warning, "L'événement n'a pas été supprimé."));
            Nav.NavigateTo("/eventsList");

        }




    }
}
