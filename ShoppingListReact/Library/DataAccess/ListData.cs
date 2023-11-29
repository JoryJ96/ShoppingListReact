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

        public IActionResult AddToShoppingList(string userID, string itemID, string listName, int requestedQuantity)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            try
            {
                dynamic p = new
                {
                    userID = userID,
                    itemID = itemID,
                    listName = listName,
                    requestedQuantity = requestedQuantity
                };

                sql.SaveData("spList_AddItem", p, "DefaultConnection");

                return new OkResult();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                return new BadRequestResult();
            }
        }

        internal List<ShoppingListItemModel> GetShoppingList(string userID, string listName)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            List<ShoppingListItemModel> shoppingList = new List<ShoppingListItemModel>();
            
            try
            {
                // The "small" version of the model contains only the itemID and quantity in the list. This prevents unnecessary columns in the ShoppingLists table
                // We can retrieve further item information just once for each itemID from there
                dynamic k = new
                {
                    UserID = userID,
                    ListName = listName
                };
                List<ShoppingListItemModel_Small> listOfIDs = sql.LoadData<ShoppingListItemModel_Small, dynamic>("spList_GetByListName", k, "DefaultConnection");

                // Get item information for each ID in the list of smalls
                foreach (ShoppingListItemModel_Small itemToParse in listOfIDs)
                {
                    dynamic p = new
                    {
                        ItemID = itemToParse.ItemID
                    };

                    ShoppingListItemModel? ParsedItem = sql.LoadData<ShoppingListItemModel, dynamic>("spItem_GetByID", p, "DefaultConnection").FirstOrDefault();

                    if (ParsedItem != null)
                    {
                        ParsedItem.RequestedQuantity = itemToParse.RequestedQuantity;

                        shoppingList.Add(ParsedItem);
                    } else
                    {
                        Console.WriteLine($"Could not find an item with that ID! Error thrown by ListData.GetShoppingList() when parsing smalls: {itemToParse.ItemID}");
                    }
                }

                return shoppingList;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);

                return shoppingList;
            }
        }

        internal ItemModel LoadFromVendor(string itemID)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            ItemModel returnModel = null;

            dynamic p = new
            {
                itemID = itemID,
            };

            try
            {
                returnModel = sql.LoadData("spItem_LoadFromVendor", p, "DefaultConnection");

                return returnModel;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);

                return returnModel;
            }
        }
    }
}
