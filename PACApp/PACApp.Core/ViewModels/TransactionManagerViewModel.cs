using PACApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACApp.Core.ViewModels
{
    public class TransactionManagerViewModel
    {
        public Transaction Transaction { get; set; }
        public IEnumerable<TransactionCategory> TransactionCategories { get; set; }
    }
}
