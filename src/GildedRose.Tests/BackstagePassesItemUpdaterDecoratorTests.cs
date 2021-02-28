using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GildedRose.Tests
{
    [TestClass]
	public class BackstagePassesItemUpdaterDecoratorTests
	{
		private readonly Mock<IItemUpdater> mockItemUpdater;
		private readonly IItemUpdater sut;

        public BackstagePassesItemUpdaterDecoratorTests()
        {
			mockItemUpdater = new Mock<IItemUpdater>();

			sut = new BackstagePassesItemUpdaterDecorator(mockItemUpdater.Object);
        }

		[TestMethod]
		public void UpdateItemCallsInnerUpdaterWhenItemIsNotBackstagePasses()
        {
            var item = ItemFactory.CreateItem();

			sut.UpdateItem(item);

			mockItemUpdater.Verify(u => u.UpdateItem(item), Times.Once);
        }

		[TestMethod]
		public void UpdateItemDoesNotCallInnerUpdaterWhenItemIsBackstagePasses()
        {
			var item = ItemFactory.CreateItem(name: ItemNames.BackstagePassesName);

			sut.UpdateItem(item);

			mockItemUpdater.Verify(u => u.UpdateItem(item), Times.Never);
        }

        [TestMethod]
		public void UpdateItemIncreasesQualityOfBackstagePassesBy1WhenSellInAbove10()
		{
			var item = ItemFactory.CreateItem(name: ItemNames.BackstagePassesName, sellIn: 11);

			sut.UpdateItem(item);

			Assert.AreEqual(11, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfBackstagePassesBy2WhenSellInAbove5()
		{
			var item = ItemFactory.CreateItem(name: ItemNames.BackstagePassesName, sellIn: 6);

			sut.UpdateItem(item);

			Assert.AreEqual(12, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfBackstagePassesBy3WhenSellInAbove0()
		{
			var item = ItemFactory.CreateItem(name: ItemNames.BackstagePassesName, sellIn: 1);

			sut.UpdateItem(item);

			Assert.AreEqual(13, item.Quality);
		}

        [TestMethod]
		public void UpdateItemSetsQualtityOfBackstagePassesTo0WhenSellInIs0()
		{
			var item = ItemFactory.CreateItem(name: ItemNames.BackstagePassesName, sellIn: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(0, item.Quality);
		}
	}
}
