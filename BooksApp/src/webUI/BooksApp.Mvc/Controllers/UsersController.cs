using BooksApp.Mvc.Models;
using BooksApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BooksApp.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            ViewBag.ReturnUrl = gidilecekSayfa;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? gidilecekSayfa)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.Name, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    return Redirect("/");

                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre yanlış!");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
