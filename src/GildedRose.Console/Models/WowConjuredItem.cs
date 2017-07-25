namespace GildedRose.Console.Models
{
    public class WowConjuredItem : WowBaseItem
    {
        public WowConjuredItem(Item item)
        {
            Item = item;
        }

        protected override void UpdateItemQuality()
        {
            if (Quality <= MinQuality) return;

            Quality = Quality - 2;
        }

        protected override void UpdateExpiredItemQuality()
        {
            if (Quality <= MinQuality) return;

            Quality = Quality - 2;
        }

    }
}