using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GildedRose.Tests
{
    [TestClass]
	public class SulfurasItemUpdaterDecoratorTests
	{
		private readonly Mock<IItemUpdater> mockItemUpdater;
		private readonly IItemUpdater sut;

        public SulfurasItemUpdaterDecoratorTests()
        {
			mockItemUpdater = new Mock<IItemUpdater>();

			sut = new SulfurasItemUpdaterDecorator(mockItemUpdater.Object);
        }

		[TestMethod]
		public void UpdateItemCallsInnerUpdaterWhenItemIsNotSulfuras()
        {
            var item = ItemFactory.CreateItem();

			sut.UpdateItem(item);

			mockItemUpdater.Verify(u => u.UpdateItem(item), Times.Once);
        }

		[TestMethod]
		public void UpdateItemDoesNotCallInnerUpdaterWhenItemIsSulfuras()
        {
			var item = ItemFactory.CreateItem(name: ItemNames.SulfurasName);

			sut.UpdateItem(item);

			mockItemUpdater.Verify(u => u.UpdateItem(item), Times.Never);
        }

        [TestMethod]
		public void UpdateItemDoesNotDecreaseQualityOfSulfuras()
		{
			var item = ItemFactory.CreateItem(name: ItemNames.SulfurasName);

			sut.UpdateItem(item);

			Assert.AreEqual(10, item.Quality);
		}

        [TestMethod]
		public void UpdateItemDoesNotDecreaseSellInOfSulfuras()
		{
			var item = ItemFactory.CreateItem(name: ItemNames.SulfurasName);

			sut.UpdateItem(item);

			Assert.AreEqual(10, item.Quality);
		}
	}
}
