using GildedRose.Console.Models;

namespace GildedRose.Console
{
    public static class WowItemFactory
    {
        public static BaseItem Create(Item item)
        {
            if(ItemIsBrie(item)) return new AgeWithGraceItem(item);
            if(ItemIsConjured(item)) return new ConjuredItem(item);
            if(ItemIsBackStagePass(item)) return new BackstagePassItem(item);
            if(ItemIsSulfaras(item)) return new LegendaryItem(item);

            return new DefaultItem(item);
        }

        private static bool ItemIsBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }
        private static bool ItemIsBackStagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool ItemIsConjured(Item item)
        {
            return item.Name.Contains("Conjured");
        }

        private static bool ItemIsSulfaras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

    }
}