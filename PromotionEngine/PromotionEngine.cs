using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PromotionEngine
{
    public class PromotionEngine : IPromotionEngine
    {
        private readonly IUnitPrice _unitPrice;
        private readonly IActivePromotions _activePromotions;

        public PromotionEngine(IUnitPrice unitPrice, IActivePromotions activePromotions)
        {
            _unitPrice = unitPrice;
            _activePromotions = activePromotions;
        }

        // IDictionary<char, int> items : {A,3}, {B,5}, {C,1}, {D,1}
        public int CheckOut(IDictionary<char, int> items)
        {
            int total = 0;
            foreach (var skuItem in items)
            {
                switch (skuItem.Key)
                {
                    case 'A':
                        int promotionQty;
                        var fixedPrice = _activePromotions.GetPromotionBySkuId('A', out promotionQty);
                        if (skuItem.Value > promotionQty)
                        {
                            total += skuItem.Value / promotionQty * fixedPrice +
                                     skuItem.Value % promotionQty * _unitPrice.GetPrice('A');
                        }
                        else
                        {
                            total += skuItem.Value * _unitPrice.GetPrice('A');
                        }
                        break;
                    case 'B':
                        fixedPrice = _activePromotions.GetPromotionBySkuId('B', out promotionQty);
                        if (skuItem.Value > promotionQty)
                        {
                            total += skuItem.Value / promotionQty * fixedPrice +
                                     skuItem.Value % promotionQty * _unitPrice.GetPrice('B');
                        }
                        else
                        {
                            total += skuItem.Value * _unitPrice.GetPrice('B');
                        }
                        break;
                    case 'C':
                        //Similar logic here
                        break;
                    case 'D':
                        //Similar logic here
                        break;
                    default:
                        total = 0;
                        break;
                }

            }

            return total;
        }
    }
}