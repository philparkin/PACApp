using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PACApp.Core.Models
{
    public class TransactionCategory : BaseEntity
    {
       
        [MaxLength(50)]
        [MinLength(1)]
        public string Category { get; set; }
        public Boolean Taxable { get; set; }

      
    }
}
