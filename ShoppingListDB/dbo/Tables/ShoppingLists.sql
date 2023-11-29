CREATE TABLE [dbo].[ShoppingLists]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserID] NVARCHAR(MAX) NOT NULL, 
    [ItemID] NVARCHAR(MAX) NOT NULL, 
    [ItemQuantity] INT NOT NULL, 
    [ListName] NVARCHAR(50) NOT NULL
)
