using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COOP_project.Models;

namespace COOP_project.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly coopDB _context;

        public BuildingsController(coopDB context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buildings.ToListAsync());
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (building == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,buildingName")] Building building)
        {
            if (ModelState.IsValid)
            {
				do
				{
					var guid = Guid.NewGuid();
					var checkGUID = _context.Buildings.Where(x => x.IdGuid == guid).FirstOrDefault();
					if (checkGUID != null)
					{
						continue;
					}
					else
					{
						building.IdGuid = guid;
						break;
					}

				}
				while (true);
				_context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Buildings/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var building =  _context.Buildings.Where(x=>x.IdGuid.ToString()==id).FirstOrDefault();
            if (building == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,buildingName")] Building building)
        {
            var buildingInfo = await _context.Buildings.AsNoTracking().Where(x => x.IdGuid.ToString() == id).FirstOrDefaultAsync();

            

                try
                {
                    building.IdGuid = buildingInfo.IdGuid;
                    building.Id = buildingInfo.Id;
                    _context.Update(building);
                    await _context.SaveChangesAsync();
					return RedirectToAction("Index", "buildings");
				}
                catch 
                {

                    ViewBag.fail = "Somthing Wrong Happended";
                    return View(buildingInfo);
                }
                
            
            
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (building == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var building = await _context.Buildings.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
