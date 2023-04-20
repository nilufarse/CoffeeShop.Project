using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [DisplayName("Role adı")]
        public string Name { get; set; }
    }
}
