using PACApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACApp.DataAccess.SQL
{
    public class DataContext :DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
           
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
    }
}
