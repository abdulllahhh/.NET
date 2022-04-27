using Facebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook.Services;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Facebook.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly RegistrationServices user;
        public AccountController()
        {
            var db = new UserIdentityContext();
            var userStore = new UserStore<MyIdentityUser>(db);
            userManager = new UserManager<MyIdentityUser>(userStore);
            user = new RegistrationServices();
        }
        /*public async Task<ActionResult> GetLoginView()
        {
            var user1 = await userManager.CreateAsync(new MyIdentityUser
            {
                Email = "Ab@faaaf.com",
                UserName = "ibrahim"
            }, "123456");
            ViewBag.User = user1.Succeeded;
            ViewBag.Err = user1.Errors.FirstOrDefault();
            return View("Login");
        }*/

       /* public ActionResult GetRegisterView()
        {
            return View("Register");
        }*/
       
       
     /*   [HttpPost]*/
       
      /*public async Task<ActionResult> Login()
        {

            *//*ViewBag.User = user.Succeeded;*/
            /*var user1 = await userManager.CreateAsync(new MyIdentityUser
            {
                Email = "Ab@fff.com",
                UserName = "abdalla"
            }, "123456");
            ViewBag.User = user1.Succeeded;*/
            /*ViewBag.User = user1.Succeeded;*/
            /*var useraccount = userManager.Find("abdalla","123456");*/
           /* ViewBag.User = useraccount.Email;*//*
            return View("login");
        }*/
      
        
        
        /* [HttpPost]
        public ActionResult Login(LoginModel userLogin)
        {
            var userService = new UserService();
            var isLoggedIn= userService.Login(userLogin.Email, userLogin.Password);

            if (isLoggedIn)
            {
                return View("~/Views/User/Profile.cshtml");
            }
            else
            {
                userLogin.message = "Email or Password is incorrect";
                return View(userLogin);
            }
        }*/



/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {

            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
*/
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl="")
        {

            return View(new LoginModel
            {
                ReturnUrl = ReturnUrl
            }) ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginData)
        {
            if (ModelState.IsValid)
            {
                var userExist = await userManager.FindAsync(loginData.Email, loginData.Password);
                if (userExist != null)
                {
                    await SignIn(userExist);
                    if (!string.IsNullOrEmpty(loginData.ReturnUrl))
                    {
                        return Redirect(loginData.ReturnUrl);
                    }
                    return RedirectToAction("GetProfileView", "User");
                }
                loginData.Message = "Email or Password is incorrect";
            }
            return View(loginData);
        }
        private async Task SignIn(MyIdentityUser myIdentityUser)
        {
            var identity =await userManager.CreateIdentityAsync(myIdentityUser, DefaultAuthenticationTypes.ApplicationCookie);
            var owinContext = Request.GetOwinContext();
            var authManeger = owinContext.Authentication;
            authManeger.SignIn(identity);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register (RegisterModel userInfo)
        {
            
            if(ModelState.IsValid)
            {
                var identityUser = new MyIdentityUser
                {
                    Email = userInfo.Email,
                    UserName = userInfo.Email

                };
                var creationResult = await userManager.CreateAsync(identityUser, userInfo.Password);
                //user created
                if(creationResult.Succeeded)
                {
                    var userId = identityUser.Id;
                    creationResult=  userManager.AddToRole(userId, "User");
                    //role assigned
                    
                    
                        //save to user tables
                        var savedUser = user.create(new User
                        {
                            Email = userInfo.Email,
                            FirstName = userInfo.FirstName,
                            LastName=userInfo.LastName,
                            Birthdate=userInfo.Birthdate,
                            City=userInfo.City,
                            Country=userInfo.Country,
                            Gender=userInfo.Gender,
                            Image=userInfo.Image,
                            Mobile=userInfo.Mobile,
                            Password=userInfo.Password
                            
                        });
                        if (savedUser==null)
                        {
                            userInfo.Message = "there is an error while regetering your Email";
                            return View(userInfo);
                        }
                    
                     return RedirectToAction("Login", "Account");
                };
                var message = creationResult.Errors.FirstOrDefault();
                ViewBag.Message = message;
                
            }
            return View(userInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var owinContext = Request.GetOwinContext();
            var authManeger = owinContext.Authentication;
            authManeger.SignOut("ApplicationCookie");
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }


    }
}