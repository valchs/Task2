using Moq;
using NUnit.Framework;
using Test2.Models;
using Test2.Repository;
using Test2.Service.Services;

namespace Test2.Tests.Services
{
	[TestFixture]
    public class ItemServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IItemRepository> _itemRepository;

        private ItemService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);

            _itemRepository = _mockRepository.Create<IItemRepository>();

            _service = new ItemService(_itemRepository.Object);
        }

        [Test]
        public void Insert_InsertsItems()
        {
            // Act
            _service.Insert(new ItemInsertModel());

            // Assert
            _itemRepository.Verify(x => x.Insert(It.IsAny<ItemInsertModel>()), Times.Once);
        }
    }
}
