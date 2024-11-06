using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_matei.Models
{
    public class Receipt
    {
        public IEnumerable<ReceiptItem> ReceiptItems { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total {  get; set; }
    }
}
