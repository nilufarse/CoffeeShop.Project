﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
