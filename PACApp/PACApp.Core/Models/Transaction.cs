using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACApp.Core.Models
{
    public class Transaction
    {
        public string Id { get; set; }
      
        public DateTime InvoiceDate { get; set; }
        public DateTime PaidDate { get; set; }

        [Range(0, 9000000)]
        public decimal Amount { get; set; }

        public Transaction()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
