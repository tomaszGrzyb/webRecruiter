using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRecruiter.Models;

namespace WebRecruiter.Controllers
{
    public class CandidateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Candidate
        public async Task<ActionResult> Index()
        {
            var candidates = db.Candidates.Include(c => c.Address).Include(c => c.Document);
            return View(await candidates.ToListAsync());
        }

        // GET: Candidate/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street");
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "SerialNumber");
            return View();
        }

        // POST: Candidate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,FirstName,SecondName,LastName,DateOfBirth,PlaceOfBirth,PhoneNumber,Pesel,AddressId,DocumentId")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street", candidate.AddressId);
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "SerialNumber", candidate.DocumentId);
            return View(candidate);
        }

        // GET: Candidate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street", candidate.AddressId);
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "SerialNumber", candidate.DocumentId);
            return View(candidate);
        }

        // POST: Candidate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,FirstName,SecondName,LastName,DateOfBirth,PlaceOfBirth,PhoneNumber,Pesel,AddressId,DocumentId")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street", candidate.AddressId);
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "SerialNumber", candidate.DocumentId);
            return View(candidate);
        }

        // GET: Candidate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            db.Candidates.Remove(candidate);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
