using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COOP_project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace COOP_project.Controllers
{
    public class MajorsController : Controller
    {
        private readonly coopDB _context;

        public MajorsController(coopDB context)
		{
            _context = context;
        }

		[Authorize(Roles = "Admin")]
		// GET: Majors
		public async Task<IActionResult> Index()
        {
            return View(await _context.Majors.ToListAsync());
        }

		[Authorize(Roles = "Admin")]
		// GET: Majors/Details/5
		public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var major = await _context.Majors
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (major == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(major);
        }

		// GET: Majors/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
        {
            return View();
        }

		// POST: Majors/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,majorName")] Major major)
        {
            do
            {
                var guid = Guid.NewGuid();
                var checkGuid = _context.Majors.Where(x => x.IdGuid == guid).FirstOrDefault();
                if (checkGuid == null)
                {
                    major.IdGuid = guid;
                    break;
                }
                else
                {
                    continue;
                }
            }
            while (true);
            try 
            {
                _context.Add(major);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.fail = "Somthing Wrong Happend";
                return View(major);
            }
        }

		// GET: Majors/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var major = await _context.Majors.AsNoTracking().Where(x=>x.IdGuid.ToString()==id).FirstOrDefaultAsync();
            if (major == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            return View(major);
        }

		// POST: Majors/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Major major)
        {
            Major majorInfo= await _context.Majors.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            //major= await _context.Majors.AsNoTracking().FirstOrDefaultAsync(x => x.IdGuid.ToString() == id);


			try
                {
                    major.IdGuid = majorInfo.IdGuid;
                    major.Id = majorInfo.Id;
                    _context.Update(major);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch 
                {
               
                    ViewBag.fail = "Somthing Wrong Happened"; 
                    return View(major);
                }
              
        }

        // GET: Majors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var major = await _context.Majors
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (major == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(major);
        }

		// POST: Majors/Delete/5
		[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var major = await _context.Majors.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            _context.Majors.Attach(major);
            _context.Entry(major).Property(x=>x.isDeleted).CurrentValue=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MajorExists(int id)
        {
            return _context.Majors.Any(e => e.Id == id);
        }
    }
}
