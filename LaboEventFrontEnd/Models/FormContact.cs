using System.ComponentModel.DataAnnotations;

namespace LaboEventFrontEnd.Models
{
    public class FormContact
    {

        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse mail valide.")]
        public string Email { get; set; }
        [Required]
        public string Object {  get; set; }
        [Required]
        public string Message { get; set; }

    }
}
