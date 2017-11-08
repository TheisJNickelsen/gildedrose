namespace GildedRose.Console.Models
{
    public class LegendaryItem : BaseItem
    {
        public LegendaryItem(Item item)
        {
            Item = item;
        }

        protected override void UpdateItemQuality()
        {
            Quality = Quality;
        }

        protected override void UpdateExpiredItemQuality()
        {
            Quality = Quality;
        }

        protected override void UpdateExpirationDays()
        {
            SellIn = SellIn;
        }
    }
}