using GildedRose.Console.Exceptions;

namespace GildedRose.Console.Models
{
    public abstract class BaseItem
    {
        public const int MaxQuality = 50;
        public const int MinQuality = 0;
        public const int BackstagePassSmallQualityIncreaseThreshold = 11;
        public const int BackstagePassLargeQualityIncreaseThreshold = 6;

        protected Item Item;

        public string Name
        {
            get => Item.Name;
            set => Item.Name = value;
        }

        public int SellIn
        {
            get => Item.SellIn;
            set => Item.SellIn = value;
        }

        public int Quality
        {
            get => Item.Quality;
            set => Item.Quality = value;
        }
        protected abstract void UpdateItemQuality();
        protected abstract void UpdateExpiredItemQuality();

        protected abstract void UpdateExpirationDays();

        private void MinQualityCheck()
        {
            if (Quality < MinQuality)
            {
                throw new QualityIsNegativeException("Item Quality cannot be negative. Item: " + Name + ", Quality: " + Quality);
            }
        }

        private void MaxQualityCheck()
        {
            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                if (Quality > MaxQuality)
                {
                    throw new MaxQualityReachedException("Max quality reached for item: " + Name + ". Quality: " + Quality);
                }
            }
        }

        public void Update()
        {
            MinQualityCheck();
            MaxQualityCheck();

            UpdateItemQuality();

            UpdateExpirationDays();

            if (ItemIsExpired())
            {
                UpdateExpiredItemQuality();
            }
        }

        private bool ItemIsExpired()
        {
            return SellIn < 0;
        }
    }
}