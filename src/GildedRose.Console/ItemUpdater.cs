using System;

namespace GildedRose.Console
{

    public class ItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
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
