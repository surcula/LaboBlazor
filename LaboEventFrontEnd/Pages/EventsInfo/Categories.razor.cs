using BlazorBootstrap;
using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LaboEventFrontEnd.Pages.EventsInfo
{
    public partial class Categories
    {
        public List<Themes> Themes { get; set; }
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public ToastService ToastService { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {            
            try
            {
                               
                HttpResponseMessage response = await Client.GetAsync("Themes");

                if (response.IsSuccessStatusCode)
                {
                    Themes = await response.Content.ReadFromJsonAsync<List<Themes>>();
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
    }
}
