using System.Threading.Tasks;
using identityCustomMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identityCustomMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModelForRegister userModelForRegister)
        {
            if (ModelState.IsValid)
            {
                if (await UserExists(userModelForRegister.UserName))
                {
                    ModelState.AddModelError("", "Kullanıcı adı zaten var.");
                    return View(userModelForRegister);
                }

                var user = new ApplicationUser
                {
                    UserName = userModelForRegister.UserName,
                    Email = userModelForRegister.Email,
                    FirstName = userModelForRegister.FirstName,
                    LastName = userModelForRegister.LastName,
                    Age = (int)userModelForRegister.Age,
                    Location = userModelForRegister.Location
                };

                var result = await userManager.CreateAsync(user, userModelForRegister.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Tarifler", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(userModelForRegister);
        }

        public IActionResult Login(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Tarifler", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModelForLogin userModelForLogin, string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userModelForLogin.UserName);

                if (user != null)
                {
                    var result = await signInManager
                        .CheckPasswordSignInAsync(user, userModelForLogin.Password, true);

                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, userModelForLogin.RememberMe);

                        return LocalRedirect(returnUrl);
                    }

                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Çok fazla şifre denemesi yaptınız. Lütfen 1 dakika bekleyiniz.");
                        return View(userModelForLogin);
                    }
                }

                ModelState.AddModelError("", "Kullanıcı adı veya Şifre bilgileri yanlış");
            }

            return View(userModelForLogin);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("/");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("", "Kullanıcı adı belirtmelisiniz");
            }
            else
            {
                var user = await userManager.FindByNameAsync(userName);

                if (user != null)
                {
                    var resetPasswordToken = await userManager.GeneratePasswordResetTokenAsync(user);

                    var resetPasswordLink = Url.Action("ResetPassword", "Account",
                        new { uid = user.Id, token = resetPasswordToken },
                        protocol: Request.Scheme);

                    // Burada şifre sıfırlama linki Email adresine gönderilebilir.

                    return Ok(resetPasswordLink);
                }

                ModelState.AddModelError("", "Kullanıcı bulunamadı");
            }

            return View();
        }

        public async Task<IActionResult> ResetPassword(string uid, string token)
        {
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(token))
                return RedirectToAction("Index");

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                return RedirectToAction("Register");
            }

            var model = new UserModelForResetPassword
            {
                UserId = uid,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserModelForResetPassword userModelForResetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userModelForResetPassword.UserId);

                if (user == null)
                {
                    return RedirectToAction("Register");
                }

                var result = await userManager.ResetPasswordAsync(user,
                    userModelForResetPassword.Token,
                    userModelForResetPassword.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(userModelForResetPassword);
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserModelForChangePassword userModelForChangePassword)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;

                var user = await userManager.FindByNameAsync(userName);

                if (user != null)
                {
                    var result = await userManager
                        .ChangePasswordAsync(user,
                            userModelForChangePassword.OldPassword,
                            userModelForChangePassword.NewPassword);

                    if (result.Succeeded)
                    {
                        ViewData["Succeed"] = true;
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        public async Task<bool> UserExists(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            return user != null;
        }
    }
}