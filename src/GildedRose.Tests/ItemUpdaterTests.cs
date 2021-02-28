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
            var item = CreateItem();

            sut.UpdateItem(item);

            Assert.AreEqual(9, item.Quality);
        }

		[TestMethod]
		public void UpdateItemDecreasesSellInBy1()
		{
            var item = CreateItem();

			sut.UpdateItem(item);

			Assert.AreEqual(9, item.SellIn);
		}

        [TestMethod]
		public void UpdateItemDecreasesQualityBy2WhenSellInIs0()
		{
            var item = CreateItem(sellIn: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(8, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotDecreaseQualityBelow0()
		{
            var item = CreateItem(quality: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(0, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfAgedBrieBy1WhenSellInAbove0()
		{
            var item = CreateItem(name: ItemNames.AgedBrieName);

			sut.UpdateItem(item);

			Assert.AreEqual(11, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfAgedBrieBy2WhenSellInIs0()
		{
            var item = CreateItem(name: ItemNames.AgedBrieName, sellIn: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(12, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotIncreaseQualityAbove50()
		{
            var item = CreateItem(name: ItemNames.AgedBrieName, quality: 50);

			sut.UpdateItem(item);

			Assert.AreEqual(50, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotDecreaseQualityOfSulfuras()
		{
			var item = CreateItem(name: ItemNames.SulfurasName);

			sut.UpdateItem(item);

			Assert.AreEqual(10, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotDecreaseSellInOfSulfuras()
		{
			var item = CreateItem(name: ItemNames.SulfurasName);

			sut.UpdateItem(item);

			Assert.AreEqual(10, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfBackstagePassesBy1WhenSellInAbove10()
		{
			var item = CreateItem(name: ItemNames.BackstagePassesName, sellIn: 11);

			sut.UpdateItem(item);

			Assert.AreEqual(11, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfBackstagePassesBy2WhenSellInAbove5()
		{
			var item = CreateItem(name: ItemNames.BackstagePassesName, sellIn: 6);

			sut.UpdateItem(item);

			Assert.AreEqual(12, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfBackstagePassesBy3WhenSellInAbove0()
		{
			var item = CreateItem(name: ItemNames.BackstagePassesName, sellIn: 1);

			sut.UpdateItem(item);

			Assert.AreEqual(13, item.Quality);
		}

        [TestMethod]
		public void UpdateItemSetsQualtityOfBackstagePassesTo0WhenSellInIs0()
		{
			var item = CreateItem(name: ItemNames.BackstagePassesName, sellIn: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(0, item.Quality);
		}

		// factory method
        private static Item CreateItem(string name = "", int quality = 10, int sellIn = 10)
        {
            return new Item { Name = name, Quality = quality, SellIn = sellIn };
        }
	}
}
