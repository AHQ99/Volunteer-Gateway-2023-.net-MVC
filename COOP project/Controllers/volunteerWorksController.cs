using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COOP_project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace COOP_project.Controllers
{
    public class volunteerWorksController : Controller
    {
        private readonly coopDB _context;

        public volunteerWorksController(coopDB context)
        {
            _context = context;
            
        }
        

        [Authorize(Roles ="Admin")]
        // GET: volunteerWorks
        public async Task<IActionResult> Index()
        {
            var coopDB = _context.VolunteerWorks.Include(v => v.User).Include(v => v.Building).Include(v => v.Major);
            return View(await coopDB.ToListAsync());
        }

		[Authorize(Roles = "Admin")]
		// GET: volunteerWorks/Details/5
		public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var volunteerWork = await _context.VolunteerWorks
                .Include(v => v.User)
                .Include(v => v.Building)
                .Include (v => v.Major)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (volunteerWork == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(volunteerWork);
        }

		[Authorize(Roles = "Admin")]
		// GET: volunteerWorks/Create
		public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users.Where(x=>x.RoleId==2), "Id", "Name");
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "buildingName");
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName");
            return View();
        }

		// POST: volunteerWorks/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,workName,Date,endDate,Desc,status,BuildingId,MajorId,numOS")] volunteerWork volunteerWork)
        {
            if (ModelState.IsValid)
            {

				do
				{
					var guid = Guid.NewGuid();
					var checkGUID = _context.VolunteerWorks.Where(x => x.IdGuid == guid).FirstOrDefault();
					if (checkGUID != null)
					{
						continue;
					}
					else
					{
						volunteerWork.IdGuid = guid;
						break;
					}

				}
				while (true);
                if(volunteerWork.endDate>volunteerWork.Date)
                {
                    try
                    {
                        _context.Add(volunteerWork);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        ViewBag.fail = "Smothing wrong happend";
                        return View();
                    }
                    
                }
                else
                {
                    ViewBag.date = "End date should be bigger than Start date";
                }
				
            }
            ViewData["UserId"] = new SelectList(_context.Users.Where(x=>x.RoleId==2), "Id", "Name", volunteerWork.UserId);
            
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "buildingName", volunteerWork.BuildingId);
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName", volunteerWork.MajorId);
            return View(volunteerWork);
        }

		
		// GET: volunteerWorks/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var volunteerWork = await _context.VolunteerWorks.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            if (volunteerWork == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.RoleId == 2), "Id", "Name", volunteerWork.UserId);
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "buildingName", volunteerWork.BuildingId);
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName", volunteerWork.MajorId);
            return View(volunteerWork);
        }

		// POST: volunteerWorks/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,[Bind("Id,UserId,workName,Date,endDate,Desc,status,BuildingId,MajorId,numOS")] volunteerWork volunteerWork)
        {
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.RoleId == 2), "Id", "Name", volunteerWork.UserId);
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "buildingName", volunteerWork.BuildingId);
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "majorName", volunteerWork.MajorId);

            var work = _context.VolunteerWorks.AsNoTracking().SingleOrDefault(x => x.IdGuid.ToString() ==id );

                try
                {
                    volunteerWork.IdGuid = work.IdGuid;
                    volunteerWork.Id = work.Id;
                    _context.Update(volunteerWork);
                    await _context.SaveChangesAsync();
                }
                catch 
                {
                    throw;
                }
               
            
            
            return RedirectToAction(nameof(Index));
        }


		
		public async Task<IActionResult> workInfo(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            
            var work = await _context.VolunteerWorks
                .Include(u => u.User)
                .Include(u => u.Building)
                .Include(u => u.Major)
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (work == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(work);

        }

		
		[HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> workInfo(string id, [Bind("id", "StudentId", "WorkId", "OrderDate,isSigned,isDone")] Order order)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var work = await _context.VolunteerWorks
                .Include(u => u.User)
                .Include(u => u.Building)
                .Include(u => u.Major)
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (User.FindFirst(ClaimTypes.Role).Value == "Student" && User.Identity.IsAuthenticated)
            {
                var check = _context.Orders.Include(x => x.Student).AsNoTracking()
                    .Where(x => x.StudentId ==int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) && x.isSigned == true && x.isDone==false)
                    .Any();
                if (work.Date > DateTime.Now)
                {
                    if(check == false)
                    {
                        do
                        {
                            var guid = Guid.NewGuid();
                            var checkGuid = _context.Orders.Where(x => x.IdGuid == guid).FirstOrDefault();
                            if (checkGuid == null)
                            {
                                order.IdGuid = guid;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        while (true);

                        order.StudentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                        order.WorkId = work.Id;
                        order.OrderDate = order.OrderDate;
                        work.numOS = work.numOS;
                        order.isSigned = true;

                        try
                        {


                            _context.Add(order);
                            work.numOS--;
                            await _context.SaveChangesAsync();
                            ViewData["succ"] = "Your Order is signed successfully";
                            if (work.numOS == 0)
                            {
                                work.status = false;
                                await _context.SaveChangesAsync();
                                return View(work);
                            }
                            return View(work);
                        }
                        catch
                        {
                            ViewData["fail"] = "Somthing Wrong Happened";
                            return View(work);
                        }
                    }
                    else
                    {
                        ViewData["sign"] = "You alredy signed to a Voulneer Work";
                    }
                   
                }
                else
                {
                    ViewData["Closed"] = "The Voulneer Work is Closed";
                }
                
            }
            else
            {

                ViewData["noP"] = "You dont have permisson to sign a voulnteer work";
            }
           

           

            
            if (work == null)
            {
				return RedirectToAction("errorP", "Home");
			}
            
            return View(work);
            
        }

		// GET: volunteerWorks/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var volunteerWork = await _context.VolunteerWorks
                .Include(v => v.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (volunteerWork == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(volunteerWork);
        }

		// POST: volunteerWorks/Delete/5
		[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vw = await _context.VolunteerWorks.AsNoTracking().FirstOrDefaultAsync(x=>x.IdGuid.ToString()==id);
            _context.Attach(vw);
            _context.Entry(vw).Property(x => x.isDeleted).CurrentValue = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool volunteerWorkExists(int id)
        {
            return _context.VolunteerWorks.Any(e => e.Id == id);
        }
    }
}
