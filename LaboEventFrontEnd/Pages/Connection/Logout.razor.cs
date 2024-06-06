using LaboEventFrontEnd.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorBootstrap;

namespace LaboEventFrontEnd.Pages.Connection
{

    public partial class Logout
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public AuthenticationStateProvider providerService { get; set; }
        [Inject]
        public NavigationManager nav { get; set; }
        [Inject]
        public ToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
            await jsRuntime.InvokeVoidAsync("localStorage.clear");
            ((MyStateProvider)providerService).NotifyUserChanged();
            ToastService.Notify(new ToastMessage(ToastType.Success,"Vous vous êtes déconnectés avec succés."));
            nav.NavigateTo("/");
        }
    }
}

