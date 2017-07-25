namespace GildedRose.Console.Models
{
    public class WowSulfarasItem : WowBaseItem
    {
        public WowSulfarasItem(Item item)
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

    }
}