using Test2.Models;
using Test2.Repository;

namespace Test2.Service.Services
{
	public class ItemService : IItemService
	{
		private readonly IItemRepository _itemRepository;

		public ItemService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		public bool Insert(ItemInsertModel item)
		{
			return _itemRepository.Insert(item);
		}
	}
}
