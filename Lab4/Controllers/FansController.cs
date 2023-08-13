using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;
using Lab4.Models.ViewModels;

namespace Lab4.Controllers {
    public class FansController : Controller {
        private readonly SportsDbContext _context;

        public FansController(SportsDbContext context) {
            _context = context;
        }

        // GET: Fans
        public async Task<IActionResult> Index(string id) {
            var viewModel = new SportClubViewModel() {
                Fans = await _context.Fans
                    .Include(i => i.Subscriptions)
                    .AsNoTracking().OrderBy(i => i.Id)
                    .ToListAsync()
            };
            if (id != null) {
                var sc = from linqtable in _context.Subscriptions
                         where linqtable.FanId == Int16.Parse(id)
                         select linqtable.SportClub;
                viewModel.SportClubs = sc;
            }
            return View(viewModel);
        }



        // GET: Fans/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Fans == null) {
                return NotFound();
            }

            var fan = await _context.Fans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fan == null) {
                return NotFound();
            }

            return View(fan);
        }

        // GET: Fans/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Fans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,BirthDate")] Fan fan) {
            if (ModelState.IsValid) {
                _context.Add(fan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fan);
        }

        // GET: Fans/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Fans == null) {
                return NotFound();
            }

            var fan = await _context.Fans.FindAsync(id);
            if (fan == null) {
                return NotFound();
            }
            return View(fan);
        }

        // POST: Fans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,BirthDate")] Fan fan) {
            if (id != fan.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(fan);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!FanExists(fan.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fan);
        }

        public async Task<IActionResult> EditSubscriptions(int? Id, string? sportclubId) {
            var viewModelFan = new FanSubscriptionViewModel() {
                Fans = await _context.Fans.Include(i => i.Subscriptions).ThenInclude(i => i.SportClub).AsNoTracking().OrderBy(i => i.Id).ToListAsync()
            };
            var viewModel = new SportClubSubscriptionViewModel() {
                SportClubs = await _context.SportClubs.Include(i => i.Subscriptions)
                    .ThenInclude(i => i.Fan).AsNoTracking().OrderBy(i => i.Id).ToListAsync()
            };

            if (Id != null) {
                ViewData["FanId"] = Id;
                viewModelFan.Subscriptions = viewModelFan.Fans.Where(i => i.Id == Id).Single().Subscriptions;

                ViewData["FullName"] = viewModelFan.Fans.Where(x => x.Id == Id).Single().FullName;
                viewModel.Subscriptions = viewModelFan.Subscriptions;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> RemoveSubscription(string? fanId, string? sportclubId) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (fanId == null || sportclubId == null) {
                return NotFound();
            }

            var fan = await _context.Fans.FirstOrDefaultAsync(i => i.Id.ToString() == fanId);
            if (fan == null) {
                return NotFound();
            }

            var subs = await _context.Subscriptions.FindAsync(Int32.Parse(fanId), sportclubId);
            if (subs == null) {
                return NotFound();

            }
            _context.Subscriptions.Remove(subs);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddSubscription([Bind("FanId, SportClubId")] Subscription sub) {
            _context.Subscriptions.Add(sub);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Fans/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Fans == null) {
                return NotFound();
            }

            var fan = await _context.Fans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fan == null) {
                return NotFound();
            }

            return View(fan);
        }

        // POST: Fans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Fans == null) {
                return Problem("Entity set 'SportsDbContext.Fans'  is null.");
            }
            var fan = await _context.Fans.FindAsync(id);
            if (fan != null) {
                _context.Fans.Remove(fan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FanExists(int id) {
            return _context.Fans.Any(e => e.Id == id);
        }
    }
}