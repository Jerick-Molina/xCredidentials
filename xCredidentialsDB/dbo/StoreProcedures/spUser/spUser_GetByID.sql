CREATE PROCEDURE [dbo].[spUser_GetByID]
	@UserID uniqueidentifier
AS
begin
	select UserID, FirstName, LastName, Email 
	from dbo.[User]
	where UserID = 	@UserID
end