CREATE PROCEDURE [dbo].[GetLocations]
AS
BEGIN
	SELECT LocationId, Location FROM Location WHERE IsValid = 'Y'
END