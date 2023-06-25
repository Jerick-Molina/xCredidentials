
CREATE TABLE [dbo].[Website]
(
	 [WebsiteID] uniqueidentifier NOT NULL DEFAULT newid() primary key, 
    [RedirectURL] NVARCHAR(MAX) NOT NULL ,
	[Owner] uniqueidentifier NOT NULL ,
	[WebsiteSecretKey] NVARCHAR(50) NOT NULL , 
    CONSTRAINT 	[FK_User]  FOREIGN KEY ([Owner])  REFERENCES [dbo].[User](UserID) ,
	
)
