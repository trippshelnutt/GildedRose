using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GildedRose.Tests
{
    [TestClass]
	public class AgedBrieItemUpdaterDecoratorTests
	{
		private readonly Mock<IItemUpdater> mockItemUpdater;
		private readonly IItemUpdater sut;

        public AgedBrieItemUpdaterDecoratorTests()
        {
			mockItemUpdater = new Mock<IItemUpdater>();

			sut = new AgedBrieItemUpdaterDecorator(mockItemUpdater.Object);
        }

		[TestMethod]
		public void UpdateItemCallsInnerUpdaterWhenItemIsNotAgedBrie()
        {
            var item = ItemFactory.CreateItem();

			sut.UpdateItem(item);

			mockItemUpdater.Verify(u => u.UpdateItem(item), Times.Once);
        }

		[TestMethod]
		public void UpdateItemDoesNotCallInnerUpdaterWhenItemIsAgedBrie()
        {
			var item = ItemFactory.CreateItem(name: ItemNames.AgedBrieName);

			sut.UpdateItem(item);

			mockItemUpdater.Verify(u => u.UpdateItem(item), Times.Never);
        }

        [TestMethod]
		public void UpdateItemIncreasesQualityOfAgedBrieBy1WhenSellInAbove0()
		{
            var item = ItemFactory.CreateItem(name: ItemNames.AgedBrieName);

			sut.UpdateItem(item);

			Assert.AreEqual(11, item.Quality);
		}

        [TestMethod]
		public void UpdateItemIncreasesQualityOfAgedBrieBy2WhenSellInIs0()
		{
            var item = ItemFactory.CreateItem(name: ItemNames.AgedBrieName, sellIn: 0);

			sut.UpdateItem(item);

			Assert.AreEqual(12, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotIncreaseQualityAbove50()
		{
            var item = ItemFactory.CreateItem(name: ItemNames.AgedBrieName, quality: 50);

			sut.UpdateItem(item);

			Assert.AreEqual(50, item.Quality);
		}
	}
}
