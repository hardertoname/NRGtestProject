using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Electricity: ProductProperties
    {
        /// <summary>
        /// rate plans
        /// </summary>
        public string RatePlans { get; set; }

        public Electricity() { }

        public Electricity(string ratePlans, int stockAmount, int saleAmount, double price) 
        {
            RatePlans = ratePlans;
            StockAmount = stockAmount;
            SaleAmount = saleAmount;
            Price = price;
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="electricity"></param>
        /// <returns></returns>
        public string Serializer(Electricity electricity)
        {
            return JsonConvert.SerializeObject(electricity);
        }

        /// <summary>
        /// DeSerialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Electricity DeSerializer(string json)
        {
            return JsonConvert.DeserializeObject<Electricity>(json);
        }

        /// <summary>
        /// if it's available to purchase
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public override bool IsAbleToBuy(int count)
        {
            if (count > StockAmount)
                return false;
            return true;
        }

        /// <param name="count"></param>
        /// <returns></returns>
        public override double Buy(int count)
        {
            StockAmount = StockAmount - count;  
            return Price * count;
        }

        /// <summary>
        /// get remaining amount
        /// </summary>
        /// <returns></returns>
        public override int GetStockAmount()
        {
            return StockAmount;
        }
    }
}
