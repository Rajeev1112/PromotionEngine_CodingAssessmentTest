using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotionEngine
    {
        int CheckOut(IDictionary<char, int> items);
    }
}