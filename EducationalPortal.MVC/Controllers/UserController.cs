using System.Data;
using System.Security.Claims;
using AutoMapper;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace EducationalPortal.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userDTO = await userService.GetUserDTOByEmailAsync(User.Identity?.Name);
            return View(mapper.Map<UserUpdateModel>(userDTO));
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegistrationModel? model)
        {
            if (ModelState.IsValid)
            {
                var registerDTOModel = mapper.Map<UserRegistrationDTO>(model);
                var userDTO = await userService.AddUserAsync(registerDTOModel);
                if (userDTO != null)
                {
                    await Authenticate(userDTO.Email, userDTO.Role.ToString());
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("Email", "UserRegisterUnique");
                }
            }
            else
            {
                ModelState.AddModelError("Password", "PasswordsRegisterError");
            }

            return RegisterUser();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel? model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = await userService.IsRegisteredUser(model.Email, model.Password);
                if (userDTO != null)
                {
                    await Authenticate(userDTO.Email, userDTO.Role.ToString());
                    return RedirectToAction("Index", "Account");
                }

                ModelState.AddModelError("General", "IncorrectLoginGeneral");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateModel updateUser)
        {
            if (!ModelState.IsValid)
            {
                return await Index();
            }

            await userService.UpdateUserAsync(mapper.Map<UserDTO>(updateUser));
            return RedirectToAction("Index", "Account");
        }

        private async Task Authenticate(string name, string role)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, name),
                new (ClaimsIdentity.DefaultRoleClaimType, role)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
