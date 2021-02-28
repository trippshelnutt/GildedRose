using GildedRose.Console;

namespace GildedRose.Tests
{
    public static class ItemFactory
    {
		// factory method
        public static Item CreateItem(string name = "", int quality = 10, int sellIn = 10)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
    }
}
