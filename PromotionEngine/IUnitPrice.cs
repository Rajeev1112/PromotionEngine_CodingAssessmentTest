using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IUnitPrice
    {
        void AddPrice(char skuId, int price);
        IDictionary<char, int> GetAllPrice();
        int GetPrice(char skuId);
    }
}