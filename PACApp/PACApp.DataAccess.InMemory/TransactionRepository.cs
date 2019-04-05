using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using PACApp.Core.Models;

namespace PACApp.DataAccess.InMemory
{
    public class TransactionRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Transaction> transactions;

        public TransactionRepository()
        {
            transactions = cache["transactions"] as List<Transaction>;
            if (transactions == null)
            {
               transactions = new List<Transaction>();
            }
        }
        public void Commit()
        {
            cache["transactions"] = transactions;
        }
        public void Insert(Transaction p)
        {
            transactions.Add(p);
        }

        public void Update(Transaction transaction)
        {
            Transaction transactionToUpdate = transactions.Find(p => p.Id == transaction.Id);

            if (transactionToUpdate != null)
            {
                transactionToUpdate = transaction;
            }
            else
            {
                throw new Exception("Transaction not found");
            }
        }

        public Transaction Find(string Id)
        {
            Transaction transaction = transactions.Find(p => p.Id == Id);

            if (transaction != null)
            {
                return transaction;
            }
            else
            {
                throw new Exception("Transaction not found");
            }
        }

        public IQueryable<Transaction> Collection()
        {
            return transactions.AsQueryable();
        }

        public void Delete(string Id)
        {
            Transaction transactionToDelete = transactions.Find(p => p.Id == Id);

            if (transactionToDelete != null)
            {
                transactions.Remove(transactionToDelete);
            }
            else
            {
                throw new Exception("Transaction not found");
            }
        }
    }
}
