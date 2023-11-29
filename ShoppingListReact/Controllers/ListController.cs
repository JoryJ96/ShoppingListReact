using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListReact.Library.DataAccess;
using ShoppingListReact.Library.Models;

namespace ShoppingListReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ListController(IConfiguration config)
        {
            _config = config;
        }

        // Create item
        [HttpPost]
        public void AddItem(string userID, string itemID, string listName, int requestedQuantity)
        {
            ListData listData = new ListData(_config);

            listData.AddToShoppingList(userID, itemID, listName, requestedQuantity);
        }

        // Get item(s)
        [HttpGet]
        public void GetItems(string userID, string listName)
        {
            ListData listData = new ListData(_config);

            // Grab all items from Shopping List
            List<ShoppingListItemModel> shoppingList = listData.GetShoppingList(userID, listName);
        }

        // Update item(s)
        [HttpPut]
        public void UpdateItem(ItemModel item) 
        { 
            throw new NotImplementedException();
        }

        [HttpDelete]
        // Delete item(s)
        public void DeleteItem(string itemID)
        {
            throw new NotImplementedException();
        }
    }
}
