using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CargoManagement.Models;

namespace CargoManagement.Controllers
{
    public class AccountsController : Controller
    {
        
        public ActionResult Loginemp()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Loginemp(LoginModel model)
        {
            using (Model1 context = new Model1())
            {
                bool IsValidUser = context.Logins.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.UserPassword == model.UserPassword);
                
                  

                if (IsValidUser)
                {
                    
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    if(model.UserType== 1)
                    {
                        return RedirectToAction("Index", "customers");
                    }
                   
                    else
                    {
                        return RedirectToAction("Display", "employees");
                    }
                        
                    
                    
                    
                }

                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }
       
        public ActionResult GetRole( )
        {
            return View();

        }
        public ActionResult GetUser()
        {
            using ( Model1 context = new Model1())
            {
                var user = context.Logins.Max();
                ViewBag.newuserId = user.ID;

            }
            return View();
        }

        [HttpGet]
        public ActionResult SetRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetRole(FormCollection f)
        {
            if (Convert.ToInt32(f["Rolename"]) == 1)
            {
                TempData["roleId"] = 1;
                TempData.Keep();
                TempData["Roleselected"] = "Admin :";
                return RedirectToAction("SignUp");

            }
            else if (Convert.ToInt32(f["Rolename"]) == 2)
            {
                TempData["roleId"] = 2;
                TempData.Keep();
                TempData["Roleselected"] = "User :";
                return RedirectToAction("SignUp");
            }
            else
            {
                TempData["roleId"] = 3;
                TempData.Keep();
                TempData["Roleselected"] = "Customer : ";
                return RedirectToAction("SignUp");
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Login model)
        {
            using(Model1 context = new Model1())
            {
                context.Logins.Add(model);
                context.SaveChanges();
                var maxId = context.Logins.Max(e => e.ID);
                ViewBag.newuserId = maxId;
                UserRolesMapping usermap = new UserRolesMapping();
                usermap.ID = maxId;
                usermap.RoleID = Convert.ToInt32(TempData["roleId"]);
                usermap.UserID = maxId;
                context.UserRolesMappings.Add(usermap);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Loginemp");
        }
    }
}