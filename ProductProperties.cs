using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class ProductProperties
    {
        public int StockAmount { get; set; }

        public int SaleAmount { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// if it's in stock
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public abstract bool IsAbleToBuy(int count);

        /// <param name="count"></param>
        /// <returns></returns>
        public abstract double Buy(int count);

        public abstract int GetStockAmount();
    }
}
