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
    public class ExamResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExamResults
        public async Task<ActionResult> Index()
        {
            var examResults = db.ExamResults.Include(e => e.ExamSubject);
            return View(await examResults.ToListAsync());
        }

        // GET: ExamResults/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = await db.ExamResults.FindAsync(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // GET: ExamResults/Create
        public ActionResult Create()
        {
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name");
            return View();
        }

        // POST: ExamResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReceivedPoints,IsAdvanced,ExamSubjectId")] ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                db.ExamResults.Add(examResult);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name", examResult.ExamSubjectId);
            return View(examResult);
        }

        // GET: ExamResults/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = await db.ExamResults.FindAsync(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name", examResult.ExamSubjectId);
            return View(examResult);
        }

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReceivedPoints,IsAdvanced,ExamSubjectId")] ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examResult).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name", examResult.ExamSubjectId);
            return View(examResult);
        }

        // GET: ExamResults/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = await db.ExamResults.FindAsync(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            ExamResult examResult = await db.ExamResults.FindAsync(id);
            db.ExamResults.Remove(examResult);
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
