using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adoum_FinalProject2022.Model
{
    class Receipt
    {

        public static string storeName = "Birreh Import-Export";
        private string customerName;
        private string productName;
        private decimal[] itemPrices;
        private DateTime purchaseDate;

        public string CustomerName
        {
            get { return customerName; }
        }


        public string ProductName
        {
            get { return productName; }
        }

        public string StoreName
        {
            get { return storeName; }
        }

        public string PurchaseDate
        {
            get { return $"{purchaseDate.Year}, {purchaseDate.Month}, {purchaseDate.Day}"; }
        }

        // List item prices
        public string ListItemPrices()
        {
            string listOfPrices = "";
            foreach (var i in itemPrices)
            {
                listOfPrices += $"{i:C} \n";
            }
            return listOfPrices;
        }


        public decimal CalculateTotal(decimal taxRate)
        {
            decimal total = 0.00m;
            foreach (var i in itemPrices)
            {
                total += i;
            }
            return (total * taxRate) + total;
        }

        public Receipt(string CustomerName, string ProductName, DateTime PurchaseDate, decimal[] ItemPrices)
        {
            customerName = CustomerName;
            productName = ProductName;
            purchaseDate = PurchaseDate;
            itemPrices = ItemPrices;
        }
    }
}
