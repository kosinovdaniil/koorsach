using System.Linq;
using System.Web.Mvc;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.WebApp.ViewModels;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISignInService _signService;

        public AccountController(IUserService userService, ISignInService signService)
        {
            _userService = userService;
            _signService = signService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "WebApp", null);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel model)
        {
            var anyUser = _userService.GetAll().Any(u => u.Email == model.Email);

            if (anyUser)
            {
                ModelState.AddModelError("", "User with that email already exists!");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Password = model.Password,
                    Email = model.Email
                };

                user = _userService.Create(user);
                if (user != null)
                {
                    _signService.IdentitySignin(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Registration error!");
            }

            return View("Register");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LogOn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.ValidateUser(model.Email, model.Password);
                if (user != null)
                {
                    _signService.IdentitySignin(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Wrong login or password!");
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            _signService.IdentitySignout();
            return RedirectToAction("Index", "Home");
        }
    }
}