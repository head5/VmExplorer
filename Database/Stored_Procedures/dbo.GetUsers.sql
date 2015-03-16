CREATE PROCEDURE [dbo].[GetUsers]
	@mid nvarchar(15)
AS
BEGIN
	SELECT MId, Domain, UserName, Password, Admin, Active FROM Users WHERE MId = @mid
END