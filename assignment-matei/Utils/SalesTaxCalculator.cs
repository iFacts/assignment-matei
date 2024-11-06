using assignment_matei.Constants;
using assignment_matei.Enums;
using assignment_matei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_matei.Utils
{
    public static class SalesTaxCalculator
    {
        public static Receipt Process(params Item[] items)
        {
            Receipt result = new Receipt();
            List<ReceiptItem> receiptItems = new List<ReceiptItem>();

            foreach (var item in items)
            {
                (decimal priceIncludingTax, decimal salesTax) = GetPriceIncludingTax(item);
                result.Total += priceIncludingTax;
                result.SalesTax += salesTax;
                receiptItems.Add(new ReceiptItem()
                {
                    ItemName = item.Name,
                    PriceIncludingSalesTax = priceIncludingTax
                });
            }

            result.ReceiptItems = receiptItems;

            return RoundResult(result);
        }

        private static (decimal, decimal) GetPriceIncludingTax(Item item)
        {
            decimal price = item.Price;
            decimal salesTax = 0m;
            decimal importTax = 0m;

            if (item.IsImported)
            {
                importTax = price * TaxMultipliers.IMPORT_TAX_MULTIPLIER;
            }

            if (IsSalesTaxApplicable(item.Category))
            {
                salesTax = price * TaxMultipliers.SALES_TAX_MULTIPLIER;
            }

            return (price + salesTax + importTax, salesTax + importTax);
        }

        private static bool IsSalesTaxApplicable(Category category)
        {
            //    I've decided to go for this approach rather than simply checking for Category.None assuming
            //  other taxable categories could be added in the future.
            if(!(category == Category.Magazines || 
                category == Category.Food ||
                category == Category.Electronics))
            {
                return true;
            }
            return false;
        }

        private static Receipt RoundResult(Receipt result)
        {
            result.Total = Math.Round(result.Total, 2);
            result.SalesTax = Math.Round(result.SalesTax, 2);

            foreach(var item in result.ReceiptItems)
            {
                item.PriceIncludingSalesTax = Math.Round(item.PriceIncludingSalesTax, 2);
            }

            return result;

        }
    }
}
