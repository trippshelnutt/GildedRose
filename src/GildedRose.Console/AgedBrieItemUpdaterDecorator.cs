namespace GildedRose.Console
{
    public class AgedBrieItemUpdaterDecorator : IItemUpdater
    {
        private readonly IItemUpdater innerUpdater;

        public AgedBrieItemUpdaterDecorator(IItemUpdater innerUpdater)
        {
            this.innerUpdater = innerUpdater;
        }

        public void UpdateItem(Item item)
        {
            if (item.Name == ItemNames.AgedBrieName)
            {
                UpdateAgedBrie(item);                
            }
            else
            {
                innerUpdater.UpdateItem(item);
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
    }
}
