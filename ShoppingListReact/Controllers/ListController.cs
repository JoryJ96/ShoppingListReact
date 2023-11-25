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
        public void AddItem(string itemID)
        {
            ListData listData = new ListData(_config);

            // Grab item from DB to add to our list
        }

        // Get item(s)
        [HttpGet]
        public void GetItems()
        {
            throw new NotImplementedException();
        }

        // Update item(s)
        [HttpPut]
        public void UpdateItem(ItemModel item) 
        { 
            throw new NotImplementedException();
        }

        // Delete item(s)
        public void DeleteItem(string itemID)
        {
            throw new NotImplementedException();
        }
    }
}
