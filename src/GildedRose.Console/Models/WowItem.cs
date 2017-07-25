using GildedRose.Console.Exceptions;

namespace GildedRose.Console.Models
{
    public class WowItem
    {
        private readonly Item _item;
        public const int MaxQuality = 50;
        public const int MinQuality = 0;

        public const int BackstagePassSmallQualityIncreaseThreshold = 11;
        public const int BackstagePassLargeQualityIncreaseThreshold = 6;

        public WowItem(Item item)
        {
            _item = item;
        }

        public string Name {
            get => _item.Name;
            set => _item.Name = value;
        }

        public int SellIn
        {
            get => _item.SellIn;
            set => _item.SellIn = value;
        }

        public int Quality
        {
            get => _item.Quality;
            set => _item.Quality = value;
        }

        public void Update()
        {
            MinQualityCheck();
            MaxQualityCheck();

            UpdateItemQuality();

            UpdateNumberOfDaysBeforeExpiration();

            if (ItemIsExpired())
            {
                UpdateExpiredItemQuality();
            }
        }

        private void UpdateItemQuality()
        {
            if (ItemIsBrie())
            {
                IncreaseBrieQuality();
            }
            else if (ItemIsBackStagePass())
            {
                IncreaseBackstagePassQuality();
            }
            else if (ItemIsConjured())
            {
                DecreaseConjuredItemQuality();
            }
            else
            {
                DecreaseQuality();
            }
        }
        public virtual void UpdateExpiredItemQuality()
        {
            if (ItemIsBrie())
            {
                IncreaseBrieQuality();
            }
            else if (ItemIsBackStagePass())
            {
                ExpireBackstagePass();
            }
            else if (ItemIsConjured())
            {
                DecreaseConjuredItemQuality();
            }
            else
            {
                DecreaseQuality();
            }
        }

        private void DecreaseConjuredItemQuality()
        {
            DecreaseQuality();
            DecreaseQuality();
        }

        private bool ItemIsBrie()
        {
            return Name == "Aged Brie";
        }
        private bool ItemIsBackStagePass()
        {
            return Name == "Backstage passes to a TAFKAL80ETC concert";
        }
        
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

        private bool ItemIsConjured()
        {
            return Name.Contains("Conjured");
        }

        private bool ItemIsExpired()
        {
            return SellIn < 0;
        }

        public virtual void IncreaseBrieQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;
            }
        }

        public virtual void IncreaseQuality()
        {
            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;
            }
        }

        private void DecreaseQuality()
        {
            if (Quality <= MinQuality) return;

            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                Quality = Quality - 1;
            }
        }

        private void UpdateNumberOfDaysBeforeExpiration()
        {
            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn = SellIn - 1;
            }
        }

        private void IncreaseBackstagePassQuality()
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

        private void ExpireBackstagePass()
        {
            Quality = Quality - Quality;
        }
    }
}