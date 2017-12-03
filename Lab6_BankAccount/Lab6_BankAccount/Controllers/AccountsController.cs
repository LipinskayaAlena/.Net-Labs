using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab6_BankAccount.Models;
using System.Linq;

namespace Lab6_BankAccount.Controllers
{
    public class AccountsController : Controller
    {
        private const String RECHARGE_OPERATION = "Recharge";

        private const String WITHDRAWAL_OPERATION = "Withdrawal";

        private const int LIMIT_YEAR = 3;

        private BankAccountEntities db = new BankAccountEntities();

        // GET: Accounts
        public ActionResult Index()
        {
            var account = db.Account.Include(a => a.TypeAccount);
            return View(account.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.TypeAccount, "Name", "Name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Date,Balance,BonusPoints,Type")] Account account)
        {
            if (ModelState.IsValid)
            {
                DateTime date = DateTime.Now; 
                long id = Int64.Parse(DateTime.Now.ToString("yyMMddhhmmss"));
                account.Id = id;
                account.Date = date.AddYears(LIMIT_YEAR);
                account.BonusPoints = 0;
                account.Balance = 0;

                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.TypeAccount, "Name", "Name", account.Type);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(long? id, String operation)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.Operation = operation;
            ViewBag.Type = new SelectList(db.TypeAccount, "Name", "Name", account.Type);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String operation, Account a)
        {
            int id = Int32.Parse(ModelState["Id"].Value.AttemptedValue);
            decimal balance = Decimal.Parse(ModelState["Balance"].Value.AttemptedValue);
            Account account = db.Account.Find(id);
            if (ModelState.IsValid) 
            {
                if(String.Equals(RECHARGE_OPERATION, operation))
                {
                    account.Balance += balance;
                }

                if (String.Equals(WITHDRAWAL_OPERATION, operation))
                {
                    account.Balance -= balance;
                }

                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.TypeAccount, "Name", "Name", account.Type);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Account account = db.Account.Find(id);
           
            db.Account.Remove(account);
            db.SaveChanges();
            
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
