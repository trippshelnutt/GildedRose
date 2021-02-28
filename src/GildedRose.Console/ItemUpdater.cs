using System;

namespace GildedRose.Console
{
    public class ItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Name == ItemNames.AgedBrieName)
            {
                UpdateAgedBrie(item);
            }
            else if (item.Name == ItemNames.BackstagePassesName)
            {
                UpdateBackstagePasses(item);
            }
            else if (item.Name == ItemNames.SulfurasName)
            {
                UpdateSulfuras(item);
            }
            else
            {
                UpdateBasicItem(item);
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }

        private void UpdateBackstagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }

        private void UpdateSulfuras(Item _)
        {
            // do nothing
        }

        private void UpdateBasicItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
