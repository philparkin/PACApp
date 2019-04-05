using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PACApp.Core.Models;
using PACApp.DataAccess.InMemory;

namespace PACApp.WebUI.Controllers
{
    public class TransactionManagerController : Controller
        
    {
        TransactionRepository context;
        public TransactionManagerController()
        {
            context = new TransactionRepository();
        }
        // GET: TransactionManager
        public ActionResult Index()        
        {
            List<Transaction> transactions = context.Collection().ToList();
            return View(transactions);
        }

        public ActionResult Create()
        {
            Transaction transaction = new Transaction();
            return View(transaction);
        }

        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return View(transaction);
            }
            else
            {
                context.Insert(transaction);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Transaction transaction = context.Find(Id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(transaction);
            }
        }

        [HttpPost]
        public ActionResult Edit(Transaction transaction, string Id)
        {
            Transaction transactionToEdit = context.Find(Id);
            if (transactionToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
            if (!ModelState.IsValid)
                {
                    return View(transaction);
                }
                transactionToEdit.Date = transaction.Date;
                transactionToEdit.Amount = transaction.Amount;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Transaction transactionToDelete = context.Find(Id);
            if (transactionToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(transactionToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Transaction transactionToDelete = context.Find(Id);
            if (transactionToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return View(transactionToDelete);
            }
        }
    }
}