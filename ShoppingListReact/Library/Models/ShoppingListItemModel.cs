namespace ShoppingListReact.Library.Models
{
    public class ShoppingListItemModel
    {
        public string Id { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public double UnitPrice { get; set; }

        public int RequestedQuantity { get; set; }

        public double TotalCost
        {
            get
            {
                return UnitPrice * RequestedQuantity;
            }
        }
    }
}
