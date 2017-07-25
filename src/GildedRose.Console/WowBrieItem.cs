namespace GildedRose.Console
{
    public class WowBrieItem : WowBaseItem
    {
        public WowBrieItem(Item item)
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

    }
}