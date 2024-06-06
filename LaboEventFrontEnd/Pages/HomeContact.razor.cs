using LaboEventFrontEnd.Models;

namespace LaboEventFrontEnd.Pages
{
    public partial class HomeContact
    {
        public FormContact MyForm {  get; set; }
        protected override void OnInitialized()
        {
            MyForm = new FormContact();
        }
        public void OnSubmitForm() 
        {
            
        }
    }
}
