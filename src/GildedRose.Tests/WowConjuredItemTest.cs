using GildedRose.Console.Models;
using Xunit;

namespace GildedRose.Tests
{
    public class WowConjuredItemTest
    {
        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems()
        {
            var conjured1 = new WowConjuredItem(new Item{ Name = "TestItem", SellIn = 10, Quality = 10 });
            var conjured2 = new WowConjuredItem(new Item { Name = "TestItem", SellIn = 0, Quality = 10 });

            conjured1.Update();
            conjured2.Update();

            Assert.True(conjured1.Quality == 8);
            Assert.True(conjured2.Quality == 6);
        }
    }
}
