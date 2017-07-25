using GildedRose.Console.Models;

namespace GildedRose.Console
{
    public static class WowItemFactory
    {
        public static WowBaseItem Create(Item item)
        {
            if(ItemIsBrie(item)) return new WowBrieItem(item);
            if(ItemIsConjured(item)) return new WowConjuredItem(item);
            if(ItemIsBackStagePass(item)) return new WowBackstagePassItem(item);
            if(ItemIsSulfaras(item)) return new WowSulfarasItem(item);

            return new WowDefaultItem(item);
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