using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        //Test builders

        [Fact]
        public void BothQualityAndSellinValuesAreLoweredEveryDay()
        {
            var testItem1 = new Item { Name = "TestItem1", SellIn = 10, Quality = 10 };
            var testItem2 = new Item { Name = "TestItem1", SellIn = 1, Quality = 50 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    testItem1,
                    testItem2
                }
            };

            app.UpdateQuality();

            Assert.True(testItem1.Quality < 10);
            Assert.True(testItem1.SellIn < 10);
            Assert.True(testItem1.Quality == 9);
            Assert.True(testItem1.SellIn == 9);

            Assert.True(testItem2.Quality < 50);
            Assert.True(testItem2.SellIn < 1);
            Assert.True(testItem2.Quality == 49);
            Assert.True(testItem2.SellIn == 0);
        }

        [Fact]
        public void QualityDegradesTwiceAsFastAfterSellDate()
        {
            var testItem1 = new Item { Name = "TestItem1", SellIn = 0, Quality = 10 };
            var testItem2 = new Item { Name = "TestItem2", SellIn = 1, Quality = 10 };
            var testItem3 = new Item { Name = "TestItem2", SellIn = 10, Quality = 10 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    testItem1,
                    testItem2,
                    testItem3
                }
            };

            app.UpdateQuality();

            Assert.True(testItem1.Quality == 8);
            Assert.True(testItem2.Quality == 9);
            Assert.True(testItem3.Quality == 9);
        }

        [Fact]
        public void FailsOnItemWithStartQualityBelowMinQuality()
        {
            var testItem1 = new Item { Name = "TestItem1", SellIn = 0, Quality = 0 };
            var testItem2 = new Item { Name = "TestItem2", SellIn = 0, Quality = -1 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    testItem1,
                    testItem2
                }
            };

            Assert.Throws<QualityIsNegativeException>(() => app.UpdateQuality());
            Assert.True(testItem1.Quality == 0);
        }

        [Fact]
        public void AgedBrieIncreasesQualityTheOlderItGets()
        {
            var agedBrie1 = new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 };
            var agedBrie2 = new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    agedBrie1,
                    agedBrie2,
                }
            };

            app.UpdateQuality();

            Assert.True(agedBrie1.Quality > 10);
            Assert.True(agedBrie1.SellIn < 10);
            Assert.True(agedBrie1.Quality == 11);
            Assert.True(agedBrie1.SellIn == 9);

            Assert.True(agedBrie2.Quality > 10);
            Assert.True(agedBrie2.SellIn < 0);
            //extra test logic. Apparently Aged Brie Quality increase is twice as fast after sell date.
            Assert.True(agedBrie2.Quality == 12);
            Assert.True(agedBrie2.SellIn == -1);
        }

        [Fact]
        public void FailsOnItemWithStartQualityAboveMaxQuality()
        {
            var testItem1 = new Item { Name = "TestItem1", SellIn = 10, Quality = 49 };
            var testItem2 = new Item { Name = "TestItem2", SellIn = 10, Quality = 50 };
            var testItem3 = new Item { Name = "TestItem2", SellIn = 10, Quality = 51 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    testItem1,
                    testItem2,
                    testItem3
                }
            };

            Assert.Throws<MaxQualityReachedException>(() => app.UpdateQuality());
            
            Assert.True(testItem1.Quality == 48);
            Assert.True(testItem2.Quality == 49);
            Assert.True(testItem3.Quality == 51);
        }

        [Fact]
        public void QualityIsNeverMoreThanMaxQuality()
        {
            var testItem1 = new Item { Name = "TestItem1", SellIn = 10, Quality = 49 };
            var testItem3 = new Item { Name = "TestItem3", SellIn = 10, Quality = 50 };

            var agedBrie1 = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };
            var agedBrie2= new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };

            var backstagePass1 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 };
            var backstagePass2 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 };
            var backstagePass3 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    testItem1,
                    testItem3,
                    agedBrie1,
                    agedBrie2,
                    backstagePass1,
                    backstagePass2,
                    backstagePass3
                }
            };

            app.UpdateQuality();

            Assert.True(testItem1.Quality == 48);
            Assert.True(testItem3.Quality == 49);

            Assert.True(agedBrie1.Quality == 50);
            Assert.True(agedBrie2.Quality == 50);

            Assert.True(backstagePass1.Quality == 50);
            Assert.True(backstagePass2.Quality == 50);
            Assert.True(backstagePass3.Quality == 0); 
        }

        [Fact]
        public void SulfarasNeverHasToBeSoldOrDecreasesInQuality()
        {
            var sulfaras1 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            var sulfaras2 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    sulfaras1,
                    sulfaras2
                }
            };

            app.UpdateQuality();

            Assert.True(sulfaras1.Quality == 80);
            Assert.True(sulfaras1.SellIn == 0);

            Assert.True(sulfaras2.Quality == 80);
            Assert.True(sulfaras2.SellIn == 10);
        }

        [Fact]
        public void BackstagePassQualityDropsTo0AfterConcert()
        {
            var bsPass1 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 };
            var bsPass2 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    bsPass1,
                    bsPass2,
                }
            };

            app.UpdateQuality();

            Assert.True(bsPass1.Quality == 13);
            Assert.True(bsPass1.SellIn == 0);

            Assert.True(bsPass2.Quality == 0);
            Assert.True(bsPass2.SellIn == -1);
        }

        [Fact]
        public void BackstagePassQualityIncreaseAsSellinValueApproaches0()
        {
            var bsPass1 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 };
            var bsPass2 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };
            var bsPass3 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 };
            var bsPass4 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 };
            var bsPass5 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
            var bsPass6 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 };
            var bsPass7 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 };
            var bsPass8 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };
            
            var app = new Program
            {
                Items = new List<Item>
                {
                    bsPass1,
                    bsPass2,
                    bsPass3,
                    bsPass4,
                    bsPass5,
                    bsPass6,
                    bsPass7,
                    bsPass8
                }
            };

            app.UpdateQuality();

            Assert.True(bsPass1.Quality == 11);
            Assert.True(bsPass1.SellIn == 10);
            Assert.True(bsPass2.Quality == 12);
            Assert.True(bsPass2.SellIn == 9);
            Assert.True(bsPass3.Quality == 12);
            Assert.True(bsPass3.SellIn == 8);

            Assert.True(bsPass4.Quality == 12);
            Assert.True(bsPass4.SellIn == 5);
            Assert.True(bsPass5.Quality == 13);
            Assert.True(bsPass5.SellIn == 4);
            Assert.True(bsPass6.Quality == 13);
            Assert.True(bsPass6.SellIn == 3);

            Assert.True(bsPass7.Quality == 13);
            Assert.True(bsPass7.SellIn == 0);
            Assert.True(bsPass8.Quality == 0);
            Assert.True(bsPass8.SellIn == -1);
        }


        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems()
        {
            var conjuredItem1 = new Item { Name = "Conjured item", SellIn = 1, Quality = 10 };
            var conjuredItem2 = new Item { Name = "Conjured item", SellIn = 0, Quality = 10 };

            var app = new Program
            {
                Items = new List<Item>
                {
                    conjuredItem1,
                    conjuredItem2
                }
            };

            app.UpdateQuality();

            Assert.True(conjuredItem1.Quality == 8);

            Assert.True(conjuredItem2.Quality == 6);
        }

    }
}