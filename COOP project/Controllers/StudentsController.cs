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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace COOP_project.Controllers
{
    public class StudentsController : Controller
    {
        private readonly coopDB _context;

        public StudentsController(coopDB context)
        {
            _context = context;
        }

        [Authorize(Roles ="Admin")]
        // GET: Students
        public async Task<IActionResult> Index()
        {

            var coopDB = _context.Students.Include(v => v.Major);
            
            return View(await coopDB.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("errorP", "Home");
            }

            var student = await _context.Students.Include(X=>X.Major)
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (student == null)
            {
                return RedirectToAction("errorP", "Home");
            }

            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,user_Name,password,Email,Phone,MajorId")] Student student)
        {
            var email = _context.Students.Where(x => x.Email == student.Email).FirstOrDefault();
            var user = _context.Students.Where(x => x.user_Name == student.user_Name).FirstOrDefault();
            var phone = _context.Students.Where(x => x.Phone == student.Phone).FirstOrDefault();


            if (ModelState.IsValid)
            {
                if (email != null)
                {
                    ViewBag.email = "This Email is alredy used";
                }
                else
                {
                    if (user != null)
                    {
                        ViewBag.user = "This User is alredy used";
                    }
                    else
                    {
                        if (phone != null)
                        {
                            ViewBag.phone = "This Phone Number is alredy used";
                        }
                        else
                        { 
                            
                            student.password = Encrypt(student.password);
                            do
                            {
                                var guid = Guid.NewGuid();
                                var checkGUID = _context.Students.Where(x => x.IdGuid == guid).FirstOrDefault();
                                if (checkGUID != null)
                                {
                                    continue;
                                }
                                else
                                {
                                    student.IdGuid = guid;
                                    break;
                                }
                                
                            }
                            while (true);
                            _context.Add(student);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }

            }

        ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName",student.MajorId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var student = await _context.Students.FirstOrDefaultAsync(x=>x.IdGuid.ToString()== id);
			
			if (student == null)
            {
                return RedirectToAction("errorP", "Home");
            }
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName", student.MajorId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,name,user_Name,password,Email,Phone,MajorId")] Student student)
        {

            var studentInfo=_context.Students.AsNoTracking().FirstOrDefault(x=>x.IdGuid.ToString() == id);

            

			ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName", student.MajorId);
                try
                {
                    student.password = studentInfo.password;
                    student.IdGuid = studentInfo.IdGuid;
                    student.Id = studentInfo.Id;
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch 
                {
                    
                    ViewBag.fail = "Somthing Wrong Happend";
                    return View(student);
                }
                
               
            
            
        }


        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (student == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            
            _context.Attach(student);
            _context.Entry(student).Property(x => x.isDeleted).CurrentValue = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
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
