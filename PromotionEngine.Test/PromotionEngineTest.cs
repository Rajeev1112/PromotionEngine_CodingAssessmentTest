using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PromotionEngine.Test
{
    [TestFixture]
    public class PromotionEngineTest
    {
        private IUnitPrice _unitPrice;
        private IActivePromotions _activePromotions;
        private IPromotionEngine _promotionEngine;

        [SetUp]
        public void Setup()
        {
            _unitPrice = new UnitPrice();
            _activePromotions = new ActivePromotions();

            _unitPrice.AddPrice('A', 50);
            _unitPrice.AddPrice('B', 30);
            _unitPrice.AddPrice('C', 20);
            _unitPrice.AddPrice('D', 15);

            _activePromotions.AddPromotions("3A", 130);
            _activePromotions.AddPromotions("2B", 45);
        }

        [TearDown]
        public void Cleanup()
        {
            _unitPrice = null;
            _activePromotions = null;
            _promotionEngine = null;
        }

        [Test]
        public void Given_4A_And_1B_When_CheckOut_Is_Called_Then_It_Should_Return_210()
        {
            // Arrange
            _promotionEngine = new PromotionEngine(_unitPrice, _activePromotions);
            IDictionary<char, int> itemsToBeCheckOut = new Dictionary<char, int>()
            {
                {'A',4 },
                {'B',1 }
            };

            // Act
            var total = _promotionEngine.CheckOut(itemsToBeCheckOut);

            // Assert
            Assert.AreEqual(210, total, "Something wrong in calculation");
        }
    }
}
