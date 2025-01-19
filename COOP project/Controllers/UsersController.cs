using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COOP_project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Data;
using System.Text;

namespace COOP_project.Controllers
{
    public class UsersController : Controller
    {
        private readonly coopDB _context;

        public UsersController(coopDB context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var coopDB = _context.Users.Include(u => u.Role);
            return View(await coopDB.ToListAsync());
        }


        [Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Admin")]
        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (user == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Create
        public IActionResult Create()
        {

            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "roleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleId,userName,Name,Password,Email,Phone")] User user)
        {
            var userEmail = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            var userName = _context.Users.Where(x => x.userName == user.userName).FirstOrDefault();
            var phone= _context.Users.Where(x=>x.Phone==user.Phone).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (userEmail != null)
                {
                    ViewBag.email = "This Email is alredy used";

                }
                else if (userName != null)
                {
                    ViewBag.user = "This User is alredy used";
                }
                else if (phone != null)
                {
                    ViewBag.phone = "This Phone Number is alredy used";

                }
                else
                {

                    user.Password = Encrypt(user.Password);
					do
					{
						var guid = Guid.NewGuid();
						var checkGUID = _context.Users.Where(x => x.IdGuid == guid).FirstOrDefault();
						if (checkGUID != null)
						{
							continue;
						}
						else
						{
							user.IdGuid = guid;
							break;
						}

					}
					while (true);
					_context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
               
                
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "roleName", user.RoleId);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
           
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var user = await _context.Users.FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            if (user == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "roleName", user.RoleId);
            return View(user);
        }


        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,[Bind("Id,RoleId,userName,Name,Password,Email,Phone")] User user)
        {

            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "roleName", user.RoleId);
            var userInfo = _context.Users.AsNoTracking().SingleOrDefault(x=>x.IdGuid.ToString() == id);
                try
                {
                    user.Id = userInfo.Id;
                    user.Password = userInfo.Password;
                    user.IdGuid=userInfo.IdGuid;
                   
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    ViewBag.fail = "Somthing wrong happened";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            
            
            
        }

        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> showprofile(string id)
        {
            if (id == null)
            {
                return RedirectToAction("errorP","Home");
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.IdGuid.ToString() == id);

            if (user == null)
            {
                return RedirectToAction("errorP", "Home");
            }
            return View(user);
        }


        public async Task<IActionResult> supDash(string id)
        {
            if(id == null)
            {
                return RedirectToAction("errorP", "Home");
            }

            var sup= await _context.Orders
                .Include(x=>x.Work.User)
                .Include(x=>x.Work.Building)
                .Include(x=>x.Work.Major)
                .Include(x=>x.Student).AsNoTracking()
                .Where(x=>x.Work.User.IdGuid.ToString()==id).ToListAsync();

            if(sup == null)
            {
                return RedirectToAction("errorP","Home");
            }
            return View(sup);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (user == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString() ==id);
            _context.Attach(user);
            _context.Entry(user).Property(x => x.isDeleted).CurrentValue = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles ="Admin")]
        public IActionResult adminPage()
        {
           
            return View();
        }

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> studentsOrders()
        {
            var orders = await _context.Orders.Include(x => x.Student)
                .Include(x => x.Work)
                .Include(x => x.Work.Building)
                .Include(x => x.Work.User).ToListAsync();
            if (orders == null) 
            {
				return RedirectToAction("errorP", "Home");
			}
            return View(orders);
        }

		[Authorize(Roles = "Admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> studentsOrders(string id, string button)
        {
            var order = await _context.Orders.AsNoTracking().Where(x => x.IdGuid.ToString() == id).FirstOrDefaultAsync();
            var works=_context.VolunteerWorks.AsNoTracking().Where(x=>x.Id == order.WorkId).FirstOrDefault();
            var orders = await _context.Orders.AsNoTracking().Include(x => x.Student)
               .Include(x => x.Work)
               .Include(x => x.Work.Building)
               .Include(x => x.Work.User).ToListAsync();

            TempData["ButtonValue"] = string.Format("{0}", button);
            try
            {
                
                _context.Attach(order);
                if(TempData["ButtonValue"].Equals("rej"))
                {
                    _context.Entry(order).Property(x => x.isSigned).CurrentValue = false;
                    _context.Entry(order).Property(x => x.isRejected).CurrentValue = true;
                    _context.Entry(order).Property(x => x.isAccepted).CurrentValue = false;
                    _context.Entry(order).Property(x => x.isDone).CurrentValue = false;
                    works.numOS++;
                    if(works.status==false)
                    {
                        works.status = true;
                    }
                }
                else if(TempData["ButtonValue"].Equals("acc")) 
                {
                    _context.Entry(order).Property(x => x.isSigned).CurrentValue = false;
                    _context.Entry(order).Property(x => x.isRejected).CurrentValue = false;
                    _context.Entry(order).Property(x => x.isAccepted).CurrentValue = true;
                    _context.Entry(order).Property(x => x.isDone).CurrentValue = false;
                }
               
                await _context.SaveChangesAsync();

                ViewBag.succ = "Task Succeeded";
                return View(orders);
            }
            catch
            {
                
                ViewBag.fail = "Smothing wrong happend";
                return View(orders);
            }
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
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
