/*CREATE DATABASE Products*/

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id=object_id(N'[dbo].[Product]'))
		BEGIN	
			CREATE TABLE [dbo].[Product]
			(	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY,
				[ProductName] NVARCHAR (255),	
				[Qty] INT NOT NULL,
				[Price] MONEY NOT NULL
			);	

			PRINT 'Table [dbo].[Product] was created';
		END
	ELSE
		PRINT 'Table  [dbo].[Product] already exists. Skipped.';

IF COL_LENGTH ('[dbo].[Product]', 'Qty' ) IS NOT NULL
		BEGIN
			ALTER TABLE [dbo].[Product]
			DROP COLUMN Qty
			PRINT 'Qty column was deleted in Product table'
		END
	ELSE
		PRINT 'Qty column is already removed in Product table'


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id=object_id(N'[dbo].[Shipment]'))
		BEGIN	
			CREATE TABLE [dbo].[Shipment]
			(	[ShipmentId] INT NOT NULL PRIMARY KEY IDENTITY,
				[ProductId] INT NOT NULL,
				[OrderId] INT NOT NULL,
				[Qty] INT NOT NULL
			);	
			
			ALTER TABLE Shipment
				ADD CONSTRAINT FK_Shipment_Product 
					FOREIGN KEY (ProductId) REFERENCES dbo.Product(ProductId);	

			ALTER TABLE Shipment
				ADD CONSTRAINT FK_Shipment_Order 
					FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId);	

			PRINT 'Table [dbo].[Shipment] was created';
		END
	ELSE
		PRINT 'Table  [dbo].[Shipment] already exists. Skipped.';

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id=object_id(N'[dbo].[Wholesaler]'))
		BEGIN	
			CREATE TABLE [dbo].[Wholesaler]
			(	
				[WholesalerId] INT NOT NULL PRIMARY KEY IDENTITY,
				[Name] NVARCHAR (255)
			);	

			PRINT 'Table [dbo].[Wholesaler] was created';
		END
	ELSE
		PRINT 'Table  [dbo].[Wholesaler] already exists. Skipped.';

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id=object_id(N'[dbo].[Order]'))
		BEGIN	
			CREATE TABLE [dbo].[Order]
			(	
				[OrderId] INT NOT NULL PRIMARY KEY IDENTITY,				
				[Name] NVARCHAR (255) UNIQUE,
				[WholesalerId] INT NOT NULL
			);	
			
			ALTER TABLE [dbo].[Order]
				ADD CONSTRAINT FK_Order_Wholesaler
					FOREIGN KEY (WholesalerId) REFERENCES dbo.Wholesaler(WholesalerId);	

			PRINT 'Table [dbo].[Order] was created';
		END
	ELSE
		PRINT 'Table  [dbo].[Order] already exists. Skipped.';
