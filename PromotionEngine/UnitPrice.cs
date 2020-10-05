using System.Collections.Generic;

namespace PromotionEngine
{
    public class UnitPrice : IUnitPrice
    {
        private readonly IDictionary<char, int> _unitPriceForSkuIds = new Dictionary<char, int>();
        
        public void AddPrice(char skuId, int price)
        {
            _unitPriceForSkuIds.Add(skuId, price);
        }

        public IDictionary<char, int> GetAllPrice()
        {
            return _unitPriceForSkuIds;
        }

        public int GetPrice(char skuId)
        {
            if (!_unitPriceForSkuIds.ContainsKey(skuId))
                return -1;

            return _unitPriceForSkuIds[skuId];
        }
    }
}