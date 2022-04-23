using HomeFinder.Data;
using HomeFinder.Models;
using HomeFinder.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HomeFinder.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly HomeFinderContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, HomeFinderContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser 
                    {   Email = model.Email, 
                        UserName = model.Email, 
                        GivenName = model.GivenName, 
                        SurName = model.SurName,
                        PhoneNumber = model.PhoneNumber,
                    };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("admin"))
                    {
                        return RedirectToAction("ListUsers", "Administrator");
                    }
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("/");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();

        }

        [HttpGet]
        public IActionResult RegisterRealtor()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterRealtor(RegisterVm model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber, GivenName = model.GivenName, SurName = model.SurName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "mäklare");
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("/");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginVm model = new LoginVm
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("", "Det gick inte att logga in");
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginVm loginViewModel = new LoginVm
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information");

                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await _userManager.CreateAsync(user);
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
            }

            ViewBag.ErrorTitle = $"We could not retreive your email from {info.LoginProvider}";
            ViewBag.ErrorMessage = "Please contact us for more information";

            return View("/home/index");
        }

    [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult MyPage()
        {
            // SKICKA ADRESS OCH BILDLÄNK TILL VIEW
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var regOfInt = _context.RegistrationOfInterest.Where(r => r.User == user).Select(r => r.RealEstate).ToList();
            //regOfInt = regOfInt.Where(r => r.User == user);

            return View(regOfInt);
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyDetails()
        {
            var id = _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return RedirectToAction("Index", "Home");
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserVm
            {
                Id = user.Id,
                Email = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles,
                UserName = user.Email,
                PhoneNumber = user.PhoneNumber
            };


            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MyDetails(EditUserVm model)
        {
                 var user = await _userManager.FindByIdAsync(model.Id);

            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return View();
            }
            else
            {
                return View("Index");
            }

        }

        [Authorize]
        public async Task<IActionResult> MyFavourites()
        {

            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var myFavourites = _context.Favourites.Where(f => f.User == user).Include(f => f.RealEstate).ToList();

            return View(myFavourites);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {

            var user = await _userManager.GetUserAsync(User);

                if (model.NewPassword.Equals(model.ConfirmPassword))
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("MyDetails");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Något gick fel, testa igen");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lösenorden matchar inte.");
                    return View();
                }
            }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }    

        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if(user != null && await _userManager.IsEmailConfirmedAsync(user))
        //        {
        //            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //            var passwordResetLink = Url.Action("ResetPasswod", "Account", new { email = model.Email, token = token }, Request.Scheme);

        //            logger.Log(LogLevel.Warning, passwordResetLink);

        //            return View("ForgotPasswordConfirmation");
        //        }
        //        return View("ForgotPasswordConfirmation");
        //    }
        //    return View(model);
        //}

        //public IActionResult ResetPassword()
        //{

        //}
    }

}
