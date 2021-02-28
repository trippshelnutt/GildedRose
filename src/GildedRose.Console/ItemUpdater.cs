namespace GildedRose.Console
{
    public class ItemUpdater
    {
        public void UpdateItem(Item item)
        {
            if (item.Name != ItemNames.AgedBrieName && item.Name != ItemNames.BackstagePassesName)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != ItemNames.SulfurasName)
                    {
                        item.Quality -= 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;

                    if (item.Name == ItemNames.BackstagePassesName)
                    {
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
                }
            }

            if (item.Name != ItemNames.SulfurasName)
            {
                item.SellIn -= 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != ItemNames.AgedBrieName)
                {
                    if (item.Name != ItemNames.BackstagePassesName)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != ItemNames.SulfurasName)
                            {
                                item.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}
