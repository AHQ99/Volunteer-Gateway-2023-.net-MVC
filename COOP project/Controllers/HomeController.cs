using COOP_project.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace COOP_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly coopDB _context;
        public HomeController(ILogger<HomeController> logger,coopDB context)
        {
            _logger = logger;
            _context = context;
        }

       
        public IActionResult Index() 
        {
            
            //HttpContext.SignInAsync(
            //           CookieAuthenticationDefaults.AuthenticationSchem);
            return View(_context.VolunteerWorks.Include(x=>x.Building).Include(x=>x.Major)); 
        }

        public IActionResult homePage()
        {

            return View();
        }

        public IActionResult errorP()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> showProfile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.Include(x=>x.Role).FirstOrDefaultAsync(x => x.IdGuid.ToString() == id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> showProfileS(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(x => x.Major).FirstOrDefaultAsync(x => x.IdGuid.ToString() == id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
