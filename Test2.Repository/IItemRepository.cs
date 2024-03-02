using Test2.Models;

namespace Test2.Repository
{
	public interface IItemRepository
	{
		bool Insert(ItemInsertModel item);
	}
}
