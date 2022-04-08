using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Advertising: ProductProperties
    {
        public Advertising() { }

        public Advertising(int saleCount, int restCount, int price)
        {
            SaleAmount = saleCount;
            StockAmount = restCount;
            Price = price;
        }

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
            StockAmount = StockAmount - count;  //remaining stock
            return Price * count;
        }

        public override int GetStockAmount()
        {
            return StockAmount;
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="advertising"></param>
        /// <returns></returns>
        public string Serializer(Advertising advertising)
        {
            return JsonConvert.SerializeObject(advertising);
        }

        /// <summary>
        /// DeSerialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Advertising DeSerializer(string json)
        {
            return JsonConvert.DeserializeObject<Advertising>(json);
        }
    }
}
