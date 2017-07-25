namespace GildedRose.Console.Models
{
    public class WowBackstagePassItem : WowBaseItem
    {
        public WowBackstagePassItem(Item item)
        {
            Item = item;
        }

        protected override void UpdateItemQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;

                if (SellIn < BackstagePassSmallQualityIncreaseThreshold)
                {
                    if (Quality < MaxQuality)
                    {
                        Quality = Quality + 1;
                    }
                }

                if (SellIn < BackstagePassLargeQualityIncreaseThreshold)
                {
                    if (Quality < MaxQuality)
                    {
                        Quality = Quality + 1;
                    }
                }
            }
        }

        protected override void UpdateExpiredItemQuality()
        {
            Quality = Quality - Quality;
        }

    }
}