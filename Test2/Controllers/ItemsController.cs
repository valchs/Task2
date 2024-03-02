using Microsoft.AspNetCore.Mvc;
using Test2.Models;
using Test2.Service.Services;

namespace Test2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly IItemService _itemService;

		public ItemsController(IItemService itemService)
		{
			_itemService = itemService;
		}

        [HttpPost]
        public async Task<IActionResult> Insert(ItemInsertModel item)
        {
			var result = _itemService.Insert(item);

			if (result)
			{
				return Ok();
			}

			return BadRequest();
        }
    }
}
