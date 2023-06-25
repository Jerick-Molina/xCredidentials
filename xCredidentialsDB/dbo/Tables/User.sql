
CREATE TABLE [dbo].[User]
(
	[UserID] uniqueidentifier NOT NULL DEFAULT newid() primary key, 
    [Email] NVARCHAR(50) NOT NULL ,
	[FirstName] NVARCHAR(50) NOT NULL ,
	[LastName] NVARCHAR(50) NOT NULL , 
	[Password] NVARCHAR(50) NOT NULL , 
	
)
