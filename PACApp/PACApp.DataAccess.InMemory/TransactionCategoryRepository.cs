using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using PACApp.Core.Models;

namespace PACApp.DataAccess.InMemory
{
    public class TransactionCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<TransactionCategory> transactionCategories;

        public TransactionCategoryRepository()
        {
            transactionCategories = cache["transactionCategories"] as List<TransactionCategory>;
            if (transactionCategories == null)
            {
                transactionCategories = new List<TransactionCategory>();
            }
        }
        public void Commit()
        {
            cache["transactionCategories"] = transactionCategories;
        }
        public void Insert(TransactionCategory p)
        {
            transactionCategories.Add(p);
        }

        public void Update(TransactionCategory transactionCategory)
        {
            TransactionCategory transactionCategoryToUpdate = transactionCategories.Find(p => p.Id == transactionCategory.Id);

            if (transactionCategoryToUpdate != null)
            {
                transactionCategoryToUpdate = transactionCategory;
            }
            else
            {
                throw new Exception("Transaction Category not found");
            }
        }

        public TransactionCategory Find(string Id)
        {
            TransactionCategory transactionCategory = transactionCategories.Find(p => p.Id == Id);

            if (transactionCategory != null)
            {
                return transactionCategory;
            }
            else
            {
                throw new Exception("Transaction Category not found");
            }
        }

        public IQueryable<TransactionCategory> Collection()
        {
            return transactionCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            TransactionCategory transactionCategoryToDelete = transactionCategories.Find(p => p.Id == Id);

            if (transactionCategoryToDelete != null)
            {
                transactionCategories.Remove(transactionCategoryToDelete);
            }
            else
            {
                throw new Exception("Transaction Category not found");
            }
        }
    }
}
