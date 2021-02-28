namespace GildedRose.Console
{
    public class SulfurasItemUpdaterDecorator : IItemUpdater
    {
        private readonly IItemUpdater innerUpdater;

        public SulfurasItemUpdaterDecorator(IItemUpdater innerUpdater)
        {
            this.innerUpdater = innerUpdater;
        }

        public void UpdateItem(Item item)
        {
            if (item.Name != ItemNames.SulfurasName)
            {
                innerUpdater.UpdateItem(item);
            }
        }
    }
}
