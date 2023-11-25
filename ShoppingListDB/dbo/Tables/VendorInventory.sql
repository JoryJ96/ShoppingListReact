CREATE TABLE [dbo].[VendorInventory] (
    [ItemID]      INT            NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Price]       REAL           NOT NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC)
);

