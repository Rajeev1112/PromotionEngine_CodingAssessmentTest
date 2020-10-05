using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IActivePromotions
    {
        void AddPromotions(string skuId, int price);

        int GetPromotionBySkuId(char skuId, out int quantity);

        IDictionary<string, int> GetActivePromotions();
    }
}