using Newtonsoft.Json;
using System;

namespace ConsoleApp1
{
    [Serializable]
    public class LightBulbs: ProductProperties
    {
        public string ManufactureAddress { get; set; }

        public DateTime ProduceDateTime { get; set; }

        public string Material { get; set; }

        public double Size { get; set; }

        public double Weight { get; set; }

        public double Power { get; set; }

        public string UserDesc { get; set; }

        public int ServiceLife { get; set; }

        public LightBulbs() { }

        /// <param name="address"></param>
        /// <param name="produceDateTime"></param>
        /// <param name="price"></param>
        /// <param name="material"></param>
        /// <param name="size"></param>
        /// <param name="weight"></param>
        /// <param name="power"></param>
        /// <param name="userDesc"></param>
        /// <param name="serviceLife"></param>
        /// <param name="restCount"></param>
        /// <param name="saleCount"></param>
        public LightBulbs(string address, DateTime produceDateTime, double price, string material, double size, double weight, double power, string userDesc, int serviceLife, int restCount, int saleCount)
        {
            ManufactureAddress = address;
            ProduceDateTime = produceDateTime;
            Price = price;
            Material = material;
            Size = size;
            Weight = weight;
            Power = power;
            UserDesc = userDesc;
            ServiceLife = serviceLife;
            StockAmount = restCount;
            SaleAmount = saleCount;
        }
        /// <summary>
        /// if avaliable to purchase
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
        /// <param name="light"></param>
        /// <returns></returns>
        public string Serializer(LightBulbs light)
        {
            return JsonConvert.SerializeObject(light);
        }

        /// <summary>
        /// DeSerialize
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public LightBulbs DeSerializer(string json)
        {
            return JsonConvert.DeserializeObject<LightBulbs>(json);
        }
    }
}
