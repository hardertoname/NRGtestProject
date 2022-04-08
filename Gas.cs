using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Gas: ProductProperties
    {
        public string RatePlans { get; set; }

        /// <summary>
        /// volumes
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Types
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ShelfLife
        /// </summary>
        public int ShelfLife { get; set; }

        /// <summary>
        /// ProduceDateTime
        /// </summary>
        public DateTime ProduceDateTime { get; set; }

        public string Desc { get; set; }

        public Gas() { }

        public Gas(string ratePlans,  double area, string type, int shelfLife, DateTime produceDateTime, int restCount, int saleCount, double price, string desc)
        {
            RatePlans = ratePlans;
            Volume = area;
            Type = type;
            ShelfLife = shelfLife;
            ProduceDateTime = produceDateTime;
            StockAmount = restCount;
            SaleAmount = saleCount;
            Price = price;
            Desc = desc;
        }

        /// <summary>
        /// if available to purchase
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

        /// <returns></returns>
        public override int GetStockAmount()
        {
            return StockAmount;
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="gas"></param>
        /// <returns></returns>
        public string Serializer(Gas gas)
        {
            return JsonConvert.SerializeObject(gas);
        }

        /// <summary>
        /// DeSerialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Gas DeSerializer(string json)
        {
            return JsonConvert.DeserializeObject<Gas>(json);
        }
    }
}
