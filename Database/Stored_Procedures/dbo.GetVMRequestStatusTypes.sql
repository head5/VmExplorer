CREATE PROCEDURE [dbo].[GetVMRequestStatusTypes]
AS
BEGIN
	SELECT Id, Status FROM VM_Request_Status
END