namespace GildedRose.Console
{
    public class BackstagePassesItemUpdaterDecorator : IItemUpdater
    {
        private readonly IItemUpdater innerUpdater;

        public BackstagePassesItemUpdaterDecorator(IItemUpdater innerUpdater)
        {
            this.innerUpdater = innerUpdater;
        }

        public void UpdateItem(Item item)
        {
            if (item.Name == ItemNames.BackstagePassesName)
            {
                UpdateBackstagePasses(item);                
            }
            else
            {
                innerUpdater.UpdateItem(item);
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
    }
}
