using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ShopMoto.Data;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using ShopMoto.Data.Repository;
using ShopMoto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace ShopMoto.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        public readonly SignInManager<User> _signInManager;
        private AppDBContext appDBContext = new AppDBContext();
        public User usersModel = new User();
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }

        [Authorize(Policy = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var externalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
            return View(new LoginViewModel
            {
                returnUrl = returnUrl,
                ExternalProviders = externalProviders
            });

        }
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "User", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);

        }
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("RegisterExternal", new ExternalLoginViewModel
            {
                returnUrl = returnUrl,
                Email = info.Principal.FindFirstValue(ClaimTypes.Email)
            });
        }
        [AllowAnonymous]
        public IActionResult RegisterExternal(ExternalLoginViewModel model)
        {
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        [ActionName("RegisterExternal")]
        public async Task<IActionResult> RegisterExternalConfirmed(ExternalLoginViewModel model)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }
            var user = new User();
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.dateTime = DateTime.Now;
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                var identityResult = await _userManager.AddLoginAsync(user, info);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index");
                    
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            usersModel.FirstName = model.FirstName;
            usersModel.Phone = model.Phone;
            usersModel.City = model.Country;
            usersModel.Country = model.City;
            usersModel.LastName = model.LastName;
            usersModel.Gender = model.Gender;
            appDBContext.Users.Update(usersModel);
            appDBContext.SaveChanges();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            usersModel.Email = userModel.Email;
            usersModel.Password = userModel.Password;
            var user = await _userManager.FindByEmailAsync(usersModel.Email);
            if (user == null)
            {
                return View(userModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, usersModel.Password, false, false);
            if (result.Succeeded)
            {
                userModel.Password = null;
                userModel.Email = null;
                return Redirect("Index");
            }
            return View(userModel);
        }
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            usersModel.Email = model.Email;
            usersModel.Password = model.Password;
            usersModel.FirstName = model.FirstName;
            usersModel.Phone = model.Phone;
            usersModel.City = model.Country;
            usersModel.Country = model.City;
            usersModel.LastName = model.LastName;
            usersModel.UserName = model.UserName;
            usersModel.dateTime = DateTime.Now;
            var user = await _userManager.FindByEmailAsync(usersModel.Email);
            if (user == null)
            {
                var result = await _userManager.CreateAsync(usersModel);
                if (result.Succeeded)
                {
                    var users = await _userManager.FindByEmailAsync(usersModel.Email);
                    await _signInManager.SignInAsync(users, false);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
