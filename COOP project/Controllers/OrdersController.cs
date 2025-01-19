using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COOP_project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace COOP_project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly coopDB _context;

        public OrdersController(coopDB context)
        {
			_context = context;
        }

		// GET: Orders
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
        {
            var coopDB = _context.Orders.Include(o => o.Student).Include(o => o.Work);
            return View(await coopDB.ToListAsync());
        }

		// GET: Orders/Details/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Student)
                .Include(o => o.Work)
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

		// GET: Orders/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
        {
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "name");
           ViewData["WorkId"] = new SelectList(_context.VolunteerWorks, "Id", "workName");
           return View();
       }

		// POST: Orders/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string radio,[Bind("Id,StudentId,WorkId,OrderDate")] Order order)
        { 
            ViewData["StudentId"] = ViewData["StudentId"] = new SelectList(_context.Students, "Id", "name", order.StudentId); ;
            ViewData["WorkId"] = new SelectList(_context.VolunteerWorks, "Id", "workName", order.WorkId);
            ViewBag.time=DateTime.Now;
            do
            {
                var guid=Guid.NewGuid();
                var checkGuid=_context.Orders.Where(x=>x.IdGuid==guid).FirstOrDefault();
                if(checkGuid==null)
                {
                    order.IdGuid=guid;
                    break;
                }
                else
                {
                    continue;
                }
            }
            while (true);
            TempData["ButtonValue"] = string.Format("{0}", radio);
            try 
            {
                if (TempData["ButtonValue"].Equals("signed"))
                {
                    order.isSigned = true;
                    order.isAccepted = false;
                    order.isRejected = false;
                    order.isDone = false;
                }
                else if (TempData["ButtonValue"].Equals("Reject"))
                {
                    order.isSigned = false;
                    order.isAccepted = false;
                    order.isRejected = true;
                    order.isDone = false;
                }
                else if (TempData["ButtonValue"].Equals("Accept"))
                {
                    order.isSigned = false;
                    order.isAccepted = true;
                    order.isRejected = false;
                    order.isDone = false;
                }
                else if (TempData["ButtonValue"].Equals("Done"))
                {
                    order.isSigned = false;
                    order.isAccepted = false;
                    order.isRejected = false;
                    order.isDone = true;
                }
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.fail = "Somthing Wrong Happened";
                return View(order);
            }
           
            
        }

        
        public async Task<IActionResult> showOrders(string id)
        {
            
            if(id==null)
            {
                return RedirectToAction("errorP", "Home");
            }
            var orders=  await _context.Orders.Include(x=>x.Student).Include(x=>x.Work).Include(x=>x.Work.Building).Include(x=>x.Work.User).Where(x=>x.Student.IdGuid.ToString() ==id ).ToListAsync();
			//ViewData["test"] = _context.Students.Where(x => x.Id == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)).SingleOrDefault().Id;
			if (orders==null)
            {
                return RedirectToAction("errorP", "Home");
            }
            return View(orders);
        }

        [HttpPost,ActionName("showOrders")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> delOrder(string id)
        {
            //var orders = await _context.Orders.Include(x => x.Student).Include(x => x.Work).Include(x => x.Work.Building).Include(x => x.Work.User).AsNoTracking().Where(x => x.Student.IdGuid.ToString()== id).ToListAsync();
            var orderId = await _context.Orders.AsNoTracking().Include(x => x.Student).Include(x => x.Work).Include(x => x.Work.Building).Include(x => x.Work.User).Where(x => x.Student.IdGuid.ToString() == id).FirstOrDefaultAsync();
            var ordersP = await _context.Orders.AsNoTracking().Include(x => x.Student).Include(x => x.Work).Include(x => x.Work.Building).Include(x => x.Work.User).Where(x => x.Student.IdGuid == orderId.Student.IdGuid).ToListAsync();
            var work = await _context.VolunteerWorks
                .Include(u => u.User)
                .Include(u => u.Building)
                .Include(u => u.Major)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == orderId.WorkId);


            try
            {
                var orders2 = await _context.Orders
                .Include(x => x.Student)
                .AsNoTracking()
                .Where(x => x.StudentId == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) && x.isSigned == true && x.isDone == false).FirstAsync();
                _context.Orders.Remove(orders2);
                if (work.status == false)
                {
                    work.status = true;
                }
                work.numOS++;
                await _context.SaveChangesAsync();
                ViewData["succ"] = "Your Order is canceled successfully";

                return View(ordersP);
            }
            catch
            {
                ViewData["fail"] = "Somthing Wrong Happend";
                return  View(ordersP);
            }

            
        }

        public async Task<IActionResult> workInfo(string id)
        {
            if (id == null)
            {
                return RedirectToAction("errorP", "Home");
            }
            ViewBag.work = new volunteerWork();
            
             var work = await _context.VolunteerWorks
                .Include(u => u.User)
                .Include(u => u.Building)
                .Include(u => u.Major)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
           
            if (work == null)
            {
                return RedirectToAction("errorP", "Home");
            }

            return View(work);

        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("errorP", "Home");
            }

            var order = await _context.Orders.AsNoTracking().Where(x=>x.IdGuid.ToString()==id).FirstOrDefaultAsync();
            if (order == null)
            {
                return RedirectToAction("errorP", "Home");
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "name", order.StudentId);
            ViewData["WorkId"] = new SelectList(_context.VolunteerWorks, "Id", "workName", order.WorkId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,string radio, [Bind("Id,StudentId,WorkId,OrderDate")] Order order)
        {
            var orderInfo = _context.Orders.AsNoTracking().Where(x=>x.IdGuid.ToString()==id).FirstOrDefault();
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "name", order.StudentId);
            ViewData["WorkId"] = new SelectList(_context.VolunteerWorks, "Id", "workName", order.WorkId);
            if (id != orderInfo.IdGuid.ToString())
            {
                return RedirectToAction("errorP","Home");
            }

            TempData["ButtonValue"] = string.Format("{0}", radio);
            try
                {
                if (TempData["ButtonValue"].Equals("signed"))
                {
                    order.isSigned = true;
                    order.isAccepted = false;
                    order.isRejected = false;
                    order.isDone = false;
                }
                else if (TempData["ButtonValue"].Equals("Reject"))
                {
                    order.isSigned = false;
                    order.isAccepted = false;
                    order.isRejected = true;
                    order.isDone = false;
                }
                else if (TempData["ButtonValue"].Equals("Accept"))
                {
                    order.isSigned = false;
                    order.isAccepted = true;
                    order.isRejected = false;
                    order.isDone = false;
                }
                else if (TempData["ButtonValue"].Equals("Done"))
                {
                    order.isSigned = false;
                    order.isAccepted = false;
                    order.isRejected = false;
                    order.isDone = true;
                }
                else if(TempData["ButtonValue"].Equals(""))
                {
                    order.isDone = orderInfo.isDone;
                    order.isSigned=orderInfo.isSigned;
                    order.isRejected=orderInfo.isRejected;
                    order.isAccepted=orderInfo.isAccepted;
                }
                order.IdGuid = orderInfo.IdGuid;
                    order.Id = orderInfo.Id;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch 
                {
                    ViewBag.fail = "somthing Wrong Happened";
                    return View(order);
                }
                
            
            
            
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            var order = await _context.Orders
                .Include(o => o.Student)
                .Include(o => o.Work)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdGuid.ToString() == id);
            if (order == null)
            {
				return RedirectToAction("errorP", "Home");
			}

            return View(order);
        }


        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var order = await _context.Orders.AsNoTracking().Where(x=>x.IdGuid.ToString()==id).FirstOrDefaultAsync();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
