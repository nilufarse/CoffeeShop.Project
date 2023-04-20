using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email adresiniz")]
        [Required(ErrorMessage = "Email tələb olunur.")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Şifrəniz")]
        [Required(ErrorMessage = "Şifrə tələb olunur.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifrəniz ən azı 4 karakterli olmalıdır.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
