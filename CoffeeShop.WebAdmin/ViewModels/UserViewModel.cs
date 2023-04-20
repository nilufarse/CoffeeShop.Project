using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [DisplayName("İstifadəçi adı")]
        public string UserName { get; set; }
        [DisplayName("Şifrə")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Mail")]
        [Required(ErrorMessage = "Email tələb olunur")]
        [EmailAddress(ErrorMessage = "Email səhvdir")]
        public string Email { get; set; }
        [DisplayName("Adı")]
        public string Name { get; set; }
        [DisplayName("Soyad")]
        public string Surname { get; set; }
    }
}
