using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SafeProgramming.Models;

namespace SafeProgramming.Controllers
{
    public class cardholderUsersController : Controller
    {
        private BankCardDBEntities db = new BankCardDBEntities();

        // GET: cardholderUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.cardholderUsers.ToListAsync());
        }

        // GET: cardholderUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardholderUsers cardholderUsers = await db.cardholderUsers.FindAsync(id);
            if (cardholderUsers == null)
            {
                return HttpNotFound();
            }
            return View(cardholderUsers);
        }

        // GET: cardholderUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cardholderUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,cardholderName,cardNumber,expDate,cvc")] cardholderUsers cardholderUsers)
        {
            if (ModelState.IsValid)
            {
                db.cardholderUsers.Add(cardholderUsers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cardholderUsers);
        }

        // GET: cardholderUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardholderUsers cardholderUsers = await db.cardholderUsers.FindAsync(id);
            if (cardholderUsers == null)
            {
                return HttpNotFound();
            }
            return View(cardholderUsers);
        }

        // POST: cardholderUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,cardholderName,cardNumber,expDate,cvc")] cardholderUsers cardholderUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardholderUsers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cardholderUsers);
        }

        // GET: cardholderUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardholderUsers cardholderUsers = await db.cardholderUsers.FindAsync(id);
            if (cardholderUsers == null)
            {
                return HttpNotFound();
            }
            return View(cardholderUsers);
        }

        // POST: cardholderUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cardholderUsers cardholderUsers = await db.cardholderUsers.FindAsync(id);
            db.cardholderUsers.Remove(cardholderUsers);
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
