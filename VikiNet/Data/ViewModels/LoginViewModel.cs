using System.ComponentModel.DataAnnotations;

namespace VikiNet.Data.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "E-posta")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
