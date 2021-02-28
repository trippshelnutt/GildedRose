namespace GildedRose.Console
{
    public static class ItemUpdaterFactory
    {
        public static IItemUpdater CreateItemUpdater()
        {
            var innerUpdater = new ItemUpdater();
            var agedBrieUpdater = new AgedBrieItemUpdaterDecorator(innerUpdater);
            var sulfurasUpdater = new SulfurasItemUpdaterDecorator(agedBrieUpdater);
            var backstagePassesUpdater = new BackstagePassesItemUpdaterDecorator(sulfurasUpdater);

            return backstagePassesUpdater;
        }
    }
}
