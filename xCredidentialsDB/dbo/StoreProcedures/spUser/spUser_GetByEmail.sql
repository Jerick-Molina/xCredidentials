CREATE PROCEDURE [dbo].[spUser_GetByEmail]
	@Email varchar(50)
AS
begin
	select UserID, FirstName, LastName, Email 
	from dbo.[User]
	where Email = @Email
end