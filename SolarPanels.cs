using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class SolarPanels:ProductProperties
    {
        public double Power { get; set; }

        public int ServiceLife { get; set; }

        public string Material { get; set; }

        /// <param name="solarPanels"></param>
        /// <returns></returns>
        public string Serializer(SolarPanels  solarPanels)
        {
            return JsonConvert.SerializeObject(solarPanels);
        }

        /// <param name="json"></param>
        /// <returns></returns>
        public SolarPanels DescSerializer(string json)
        {
            return JsonConvert.DeserializeObject<SolarPanels>(json);
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
            StockAmount = StockAmount - count;  
            return Price * count;
        }

        /// <returns></returns>
        public override int GetStockAmount()
        {
            return StockAmount;
        }
    }
}
