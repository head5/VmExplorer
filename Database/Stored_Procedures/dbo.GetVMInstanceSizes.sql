CREATE PROCEDURE [dbo].[GetVMInstanceSizes]
AS
BEGIN
	SELECT ID, Name, Memory, Core, Active FROM VM_Instance_Size
END