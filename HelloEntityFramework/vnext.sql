CREATE DATABASE Products

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