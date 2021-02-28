using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
	public class ItemUpdaterTests
	{
        private ItemUpdater sut = new ItemUpdater();

		[TestMethod]
		public void UpdateItemDecreasesQualityBy1()
        {
            var item = ItemFactory.CreateItem();

            sut.UpdateItem(item);

            Assert.AreEqual(9, item.Quality);
        }

		[TestMethod]
		public void UpdateItemDecreasesSellInBy1()
		{
            var item = ItemFactory.CreateItem();

			sut.UpdateItem(item);

			Assert.AreEqual(9, item.SellIn);
		}

        [TestMethod]
		public void UpdateItemDecreasesQualityBy2WhenSellInIs0()
		{
            var item = ItemFactory.CreateItem(sellIn: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(8, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotDecreaseQualityBelow0()
		{
            var item = ItemFactory.CreateItem(quality: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(0, item.Quality);
		}
	}
}
