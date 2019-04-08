using PACApp.Core.Models;
using PACApp.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PACApp.WebUI.Controllers
{
    public class TransactionCategoryManagerController : Controller
    {
        TransactionCategoryRepository context;
        public TransactionCategoryManagerController()
        {
            context = new TransactionCategoryRepository();
        }
        // GET: TransactionCategoryManager
        public ActionResult Index()
        {
            List<TransactionCategory> transactionCategories = context.Collection().ToList();
            return View(transactionCategories);
        }

        public ActionResult Create()
        {
            TransactionCategory transactionCategory = new TransactionCategory();
            return View(transactionCategory);
        }

        [HttpPost]
        public ActionResult Create(TransactionCategory transactionCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(transactionCategory);
            }
            else
            {
                context.Insert(transactionCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            TransactionCategory transactionCategory = context.Find(Id);
            if (transactionCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(transactionCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(TransactionCategory transactionCategory, string Id)
        {
            TransactionCategory transactionCategoryToEdit = context.Find(Id);
            if (transactionCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(transactionCategory);
                }
                transactionCategoryToEdit.Category = transactionCategory.Category;
                transactionCategoryToEdit.Taxable = transactionCategory.Taxable;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            TransactionCategory transactionCategoryToDelete = context.Find(Id);
            if (transactionCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(transactionCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            TransactionCategory transactionCategoryToDelete = context.Find(Id);
            if (transactionCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return View(transactionCategoryToDelete);
            }
        }
    }
}