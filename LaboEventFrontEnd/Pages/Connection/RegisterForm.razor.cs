using BlazorBootstrap;
using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;


namespace LaboEventFrontEnd.Pages.Connection
{
    public partial class RegisterForm
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public ToastService ToastService { get; set; }

        public RegisterUserForm MyForm { get; set; }


        protected override void OnInitialized()
        {
            MyForm = new RegisterUserForm();
        }
        public async Task OnSubmitForm()
        {
            try
            {
                HttpResponseMessage response = await Client.PostAsJsonAsync("Auth/register", MyForm);
                if (response.IsSuccessStatusCode)
                {
                    ToastService.Notify(new ToastMessage(ToastType.Warning, "Vous êtes inscrit avec succès."));
                    Nav.NavigateTo("/");
                }
                else
                {
                    ToastService.Notify(new ToastMessage(ToastType.Warning, "Une erreur est surevenue, veuillez réessayer plus tard ou contacter l'admin."));
                }
            }
            catch (HttpRequestException ex)
            {
                ToastService.Notify(new ToastMessage(ToastType.Warning, "Une erreur est surevenue, veuillez réessayer plus tard ou contacter l'admin.")); 
            }
        }
    }
}
