using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class ActivePromotions : IActivePromotions
    {
        private readonly IDictionary<string, int> _promotions = new Dictionary<string, int>();
        
        public void AddPromotions(string skuId, int price)
        {
            _promotions.Add(skuId, price);
        }

        public int GetPromotionBySkuId(char skuId, out int quantity)
        {
            foreach (var key in _promotions.Keys)
            {
                if (key.Contains(skuId.ToString()))
                {
                    quantity = int.Parse(key.Substring(0, key.Length - 2));
                    return _promotions[key];
                }
            }

            quantity = 0;
            return 0;
        }

        public IDictionary<string, int> GetActivePromotions()
        {
            return _promotions;
        }
    }
}