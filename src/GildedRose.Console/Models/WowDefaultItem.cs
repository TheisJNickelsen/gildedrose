namespace GildedRose.Console.Models
{
    public class WowDefaultItem : WowBaseItem
    {
        public WowDefaultItem(Item item)
        {
            Item = item;
        }

        protected override void UpdateItemQuality()
        {
            if (Quality <= MinQuality) return;

            Quality = Quality - 1;
        }

        protected override void UpdateExpiredItemQuality()
        {
            if (Quality <= MinQuality) return;

            Quality = Quality - 1;
        }

    }
}