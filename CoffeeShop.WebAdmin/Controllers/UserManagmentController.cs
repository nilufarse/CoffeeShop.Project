using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.Controllers
{

    //[Authorize(Roles = "SuperAdmin")]
    public class UserManagmentController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public UserManagmentController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region UserOperation
        public IActionResult UserIndex()
        {

            List<UserViewModel> viewModels = new List<UserViewModel>();

            List<AppUser> appUsers = _userManager.Users.ToList();
            foreach (var item in appUsers)
            {
                UserViewModel viewModel = new UserViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Email = item.Email,
                    UserName = item.UserName,

                };
                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }

        public IActionResult UserCreate()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {

                    Name = viewModel.Name,
                    Surname = viewModel.Surname,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                };
                IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserIndex");
                }

            }
            return View(viewModel);

        }
        public async Task<IActionResult> UserUpdate(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            UserViewModel viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserViewModel viewModel)
        {
            AppUser user = await _userManager.FindByIdAsync(viewModel.Id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = viewModel.Name;
            user.Surname = viewModel.Surname;
            user.Email = viewModel.Email;
            user.UserName = viewModel.UserName;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["success"] = "User have been successfully changed.";
                return RedirectToAction("UserIndex");
            }
            //}

            return View(viewModel);
        }

        public async Task<IActionResult> UserDelete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["success"] = "User have been successfully deleted.";
                    return RedirectToAction("UserIndex");
                }
            }
            return RedirectToAction("UserIndex");
        }

        #endregion

        #region RoleOperation
        public async Task<string> UserRole(string id)
        {

            AppUser user = await _userManager.FindByIdAsync(id);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            StringBuilder builder = new StringBuilder();
            foreach (var item in roles)
            {
                builder.Append(item + "; ");
            }
            return builder.ToString();
        }

        public IActionResult RoleIndex()
        {

            List<RoleViewModel> viewModels = new List<RoleViewModel>();

            List<AppRole> appRoles = _roleManager.Roles.ToList();
            foreach (var item in appRoles)
            {
                RoleViewModel viewModel = new RoleViewModel
                {
                    Id = item.Id,
                    Name = item.Name

                };
                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }
        public IActionResult RoleCreate()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            AppRole role = new AppRole()
            {
                Name = viewModel.Name
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["success"] = "Role added successfully. ";
                return RedirectToAction("RoleIndex");
            }

            //}
            return View(viewModel);

        }


        //public async Task<IActionResult> RoleAssign(string Id)
        //{
        //    AppUser user = await _userManager.FindByIdAsync(Id);

        //    UserRoleViewModel viewModel = new UserRoleViewModel()
        //    {
        //        UserFullName = user.Name + " " + user.Surname,
        //        UserId = user.Id
        //    };
        //    List<AppRole> roles = _roleManager.Roles.ToList();

        //    List<RoleViewModel> roleViewModels = new List<RoleViewModel>();
        //    foreach (var item in roles)
        //    {
        //        RoleViewModel roleView = new RoleViewModel()
        //        {
        //            Id = item.Id,
        //            Name = item.Name,
        //        };
        //        roleViewModels.Add(roleView);
        //    }
        //    viewModel.Roles = roleViewModels;
        //    return View(viewModel);

        //}

        //[HttpPost]
        //public async Task<IActionResult> RoleAssign(UserRoleViewModel viewModel)
        //{
        //    AppUser user = await _userManager.FindByIdAsync(viewModel.UserId);
        //    if (user != null)
        //    {
        //        IdentityResult result = await _userManager.AddToRoleAsync(user, viewModel.RoleName);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("UserIndex");
        //        }
        //    }


        //    return View(viewModel);

        //}

        public async Task<IActionResult> RoleAssign(string Id)
        {
            AppUser user = await _userManager.FindByIdAsync(Id);

            UserRoleViewModel viewModel = new UserRoleViewModel()
            {
                UserFullName = user.Name + " " + user.Surname,
                UserId = user.Id
            };
            List<AppRole> roles = _roleManager.Roles.ToList();

            List<RoleViewModel> roleViewModels = new List<RoleViewModel>();
            foreach (var item in roles)
            {
                RoleViewModel roleView = new RoleViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                roleViewModels.Add(roleView);
            }
            viewModel.Roles = roleViewModels;
            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(UserRoleViewModel viewModel)
        {
            AppUser user = await _userManager.FindByIdAsync(viewModel.UserId);
            if (user != null)
            {
                IdentityResult result = await _userManager.AddToRoleAsync(user, viewModel.RoleName);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserIndex");
                }
            }


            return View(viewModel);

        }


        public async Task<IActionResult> RoleUpdate(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            RoleViewModel viewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            AppRole role = await _roleManager.FindByIdAsync(viewModel.Id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = viewModel.Name;
            IdentityResult result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                TempData["success"] = "Role have been successfully changed.";
                return RedirectToAction("RoleIndex");
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> RoleDelete(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["success"] = "Role have been successfully deleted.";
                return RedirectToAction("RoleIndex");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        #endregion
    }
}