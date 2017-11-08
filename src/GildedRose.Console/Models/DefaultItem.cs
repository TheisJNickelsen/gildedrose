namespace GildedRose.Console.Models
{
    public class DefaultItem : BaseItem
    {
        public DefaultItem(Item item)
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

        protected override void UpdateExpirationDays()
        {
            SellIn = SellIn - 1;
        }

    }
}