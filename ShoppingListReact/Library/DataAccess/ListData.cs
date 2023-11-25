using Microsoft.AspNetCore.Mvc;
using ShoppingListReact.Library.DataAccess.Internal;
using ShoppingListReact.Library.Models;

namespace ShoppingListReact.Library.DataAccess
{
    public class ListData
    {
        private readonly IConfiguration _config;

        public ListData(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult AddItem(ItemModel item)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            try
            {
                sql.SaveData("spItem_AddToList", item, "DefaultConnection");

                return new OkResult();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                return new BadRequestResult();
            }
        }
    }
}
