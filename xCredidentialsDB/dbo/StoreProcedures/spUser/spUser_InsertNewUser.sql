CREATE PROCEDURE [dbo].[spUser_InsertNewUser]
	@Email varchar(50),
	@Password varchar(50),
	@FirstName varchar(50),
	@LastName varchar(50)

AS
begin
	insert into dbo.[User] (Email,Password,FirstName,LastName)
	values (@Email,@Password,@FirstName,@LastName);
end