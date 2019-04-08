using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACApp.Core.Models
{
    public class TransactionCategory
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public Boolean Taxable { get; set; }

        public TransactionCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
