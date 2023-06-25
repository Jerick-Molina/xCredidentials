CREATE PROCEDURE [dbo].[spUser_GetByAuthentication]
@Email varchar(50),
@Password varchar(50)
AS
begin
	select UserID, FirstName, LastName, Email 
	from dbo.[User]
	where Email = @Email AND  Password = @Password
end