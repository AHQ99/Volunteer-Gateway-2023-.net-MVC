using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COOP_project.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;

namespace COOP_project.Controllers
{
	public class LoginController : Controller
	{
        private readonly coopDB _context;
       
        public LoginController(coopDB context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {

            return View();
        }

       

      

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoginPage()
        {
            try
            {
                string UserName = User.FindFirst(ClaimTypes.Name).Value;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserLogin()
        {
            try
            {
                string UserName = User.FindFirst(ClaimTypes.Name).Value;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UserLogin(string userName,string Password)
        {
            
            try
            {

                var check = _context.Users.Include(x=>x.Role).Where(z => z.userName == userName && z.Password == Encrypt(Password) && z.isDeleted==false).SingleOrDefault();
                if (check == null)
                {
                    ViewBag.fail = "The user name and password is wrong";
                    return View();
                }
                else
                {
                    

                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, check.userName),
                    new Claim(ClaimTypes.Role, check.Role.roleName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, check.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, check.Name),
                    new Claim(ClaimTypes.Hash, check.IdGuid.ToString())
                    
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);

                    //HttpContext.Session.SetString("sessionUser",JsonConvert.SerializeObject(principal));

                    if(principal.Identity.IsAuthenticated && principal.FindFirst(ClaimTypes.Role).Value=="Admin")
                    {
                        return RedirectToAction("adminPage", "Users");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
            }
            catch
            {
                ViewBag.fail = "Somthing Wrong Happend";
                return View();
            }

        }

       

        [HttpGet]
        [AllowAnonymous]
        public IActionResult StudentLogin()
        {
            try
            {
                string UserName = User.FindFirst(ClaimTypes.Name).Value;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }



        public IActionResult changePasswordUser(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var user = _context.Users.Include(x => x.Role).Where(x => x.IdGuid.ToString() == id).FirstOrDefault();
            if (user == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> changePasswordUser(string id, string pass1, string pass2, [Bind("Id,name,user_Name,password,Email,Phone,MajorId")] User user)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            if (pass1 == pass2)
            {
                if(pass1 !=null && pass2 != null)
                {
                    try
                    {
                        var pass = _context.Users.Include(x => x.Role).Where(x => x.IdGuid.ToString() == id).FirstOrDefault();
                        user.IdGuid = pass.IdGuid;
                        _context.Attach(pass);
                        _context.Entry(pass).Property(x => x.Password).CurrentValue = Encrypt(pass1);
                        await _context.SaveChangesAsync();
                        ViewBag.succ = "The password has changed succefully";
                        return View(user);
                    }
                    catch
                    {
                        ViewBag.fail = "Somthing wrong happend";
                        return View(user);
                    }
                }
                else
                {
                    ViewBag.emp = "Password should not be empty";
                    return View(user);
                }
                
                
            }
            else
            {
                ViewBag.wrong = "The passwords should be the same";
                return View(user);
            }



        }


        public IActionResult changePassword(string id)
        {
            if(id== null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var student=_context.Students.Include(x=>x.Major).Where(x=>x.IdGuid.ToString() ==id).FirstOrDefault();
            if(student==null)
            {
                return RedirectToAction("errorP", "Home");
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> changePassword(string id,string pass1,string pass2, [Bind("Id,name,user_Name,password,Email,Phone,MajorId")] Student student)
        {
            if (id == null)
            {
                return RedirectToAction("errorP", "Home");
            }
            
            if(pass1 == pass2)
            {
                if (pass1 != null && pass2 != null)
                {
                    try
                    {
                        var pass = _context.Students.Include(x => x.Major).Where(x => x.IdGuid.ToString() == id).FirstOrDefault();
                        _context.Attach(pass);
                        _context.Entry(pass).Property(x => x.password).CurrentValue = Encrypt(pass1);
                        await _context.SaveChangesAsync();
                        ViewBag.succ = "The password has changed succefully";
                        return View(student);
                    }
                    catch
                    {
                        ViewBag.fail = "Somthing wrong happend";
                        return View(student);
                    }
                }
                else
                {
                    ViewBag.wrong = "The passwords should not be empty";
                    return View(student);
                }
                
            }
            else
            {
                ViewBag.wrong = "The passwords should be the same";
                return View(student);
            }
            
            
           
        }

       

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            try
            {
                string UserName = User.FindFirst(ClaimTypes.Name).Value;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
            

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgetPassword(string Email)
        {
           
            var emailCheck = _context.Students.Where(s => s.Email == Email).FirstOrDefault();
            // Get the email address to send the message to
            if (emailCheck == null)
            {
                ViewBag.email = "This email does not exist";
                return View();
            }
            else
            {
                try
                {
                    //// Get the student's email



                    var emailTo = Email;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("doher6.gogle@gmail.com"),
                        Subject = "Thank you for your request",
                        Body = "<h1>Enter a new password in this link</h1> " +
                        "<a href="+"https://localhost:44312/login/changePassword/"+emailCheck.IdGuid.ToString()+">Change Password</a>",
                        IsBodyHtml = true,
                        Sender= new MailAddress("doher6.gogle@gmail.com"),
					};

                    var MailClient = new SmtpClient("smtp.gmail.com", 587)
                    {
                        
                        EnableSsl = true,
                        Credentials = new System.Net.NetworkCredential("cooptraning@gmail.com", "vsstbvnrhgmgshzs"),
                        
                    };
                    

					mailMessage.To.Add(emailTo);
                    MailClient.Send(mailMessage);
                    ViewBag.succ = "Sent succefully";
                    return View();
                }
                catch
                {
                    // Handle the error
                    ViewBag.fail = "Sent Failed";

                }
            }
           

            return View();

        }

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgetPasswordUser()
		{
			try
			{
				string UserName = User.FindFirst(ClaimTypes.Name).Value;
				return RedirectToAction("Index", "Home");
			}
			catch
			{
				return View();
			}


		}

		[HttpPost]
        [AllowAnonymous]
        public IActionResult ForgetPasswordUser(string Email)
        {

            var emailCheck = _context.Users.Where(s => s.Email == Email).FirstOrDefault();
            // Get the email address to send the message to
            if (emailCheck == null)
            {
                ViewBag.email = "This email does not exist";
                return View();
            }
            else
            {
                try
                {
                    //// Get the student's email



                    var emailTo = Email;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("cooptraning@gmail.com"),
                        Subject = "Thank you for your request",
                        Body = "<h1>Enter a new password in this link</h1> " +
                        "<a href=" + "https://localhost:44312/login/changePasswordUser/" + emailCheck.IdGuid.ToString() + ">Change Password</a>",
                        IsBodyHtml = true,
                    };

                    var MailClient = new SmtpClient("smtp.gmail.com", 587)
                    {

                        EnableSsl = true,

                        Credentials = new System.Net.NetworkCredential("cooptraning@gmail.com", "vsstbvnrhgmgshzs"),

                    };

                    mailMessage.To.Add(emailTo);
                    MailClient.Send(mailMessage);
                    ViewBag.succ = "Sent succefully";
                    return View();
                }
                catch
                {
                    // Handle the error
                    ViewBag.fail = "Sent Failed";

                }
            }


            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> StudentLogin(string user_Name, string password)
        {

            try
            {
                var checkst = _context.Students.Include(x=>x.Major).Where(x => x.user_Name == user_Name && x.password ==Encrypt(password) && x.isDeleted==false).SingleOrDefault();
                
                if (checkst == null)
                {
                    
                    ViewBag.fail = "The user name and password is wrong";
                    return View();
                }
                else
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, checkst.user_Name),
                    new Claim(ClaimTypes.Role, "Student"),
                    new Claim(ClaimTypes.NameIdentifier, checkst.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, checkst.name),
                    new Claim(ClaimTypes.Hash,checkst.IdGuid.ToString())
                    
                   
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);

                   return RedirectToAction("Index", "Home");

                }
            }
            catch
            {
                ViewBag.fail = "Somthing Wrong Happend";
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        public string Encrypt(string password)
        {
            string salt = "Archive";
            string GenPass = password + salt;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(GenPass));
                return Convert.ToBase64String(data);
            }
        }
    }
}
