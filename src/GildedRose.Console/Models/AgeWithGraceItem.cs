namespace GildedRose.Console.Models
{
    public class AgeWithGraceItem : BaseItem
    {
        public AgeWithGraceItem(Item item)
        {
            Item = item;
        }

        protected override void UpdateItemQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;
            }
        }

        protected override void UpdateExpiredItemQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;
            }
        }

        protected override void UpdateExpirationDays()
        {
            SellIn = SellIn - 1;
        }

    }
}