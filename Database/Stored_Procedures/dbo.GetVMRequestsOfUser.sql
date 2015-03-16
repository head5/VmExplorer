CREATE PROCEDURE [dbo].[GetVMRequestsOfUser]
	@mid varchar(11),
	@status varchar(10)
AS
BEGIN
	IF (@status = 'ALL')
		BEGIN
			SELECT r.Request_Id 'ID', r.VMName, r.Image_Name 'OS', i.Name 'Size', l.Location, r.Current_Status 'Status'
			FROM VM_Request r
			JOIN VM_Instance_Size i
			ON r.VM_Instance_Size_Id = i.Id
			JOIN Location l
			ON r.LocationId = l.LocationId
			WHERE r.Mid = @mid
		END
	ELSE
		BEGIN
			SELECT r.Request_Id 'ID', r.VMName, r.Image_Name 'OS', i.Name 'Size', l.Location, r.Current_Status 'Status'
			FROM VM_Request r
			JOIN VM_Instance_Size i
			ON r.VM_Instance_Size_Id = i.Id
			JOIN Location l
			ON r.LocationId = l.LocationId
			WHERE r.Mid = @mid AND r.Current_Status = @status
		END
RETURN 0
END