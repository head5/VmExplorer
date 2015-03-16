CREATE PROCEDURE [dbo].[AddVMRequest]
	@mid varchar(11),
	@vm_name varchar(20),
	@vminstance_size_id int,
	@image_name varchar(MAX),
	@location_id int,
	@vm_request_status varchar(10),
	@vm_request_status_id int,
	@id int = 0,
	@result varchar(25) OUTPUT
AS
BEGIN
	SET @result = 'Fail'

	INSERT INTO VM_Request (Mid, VMName, VM_Instance_Size_Id, Image_Name, LocationId, Current_Status, Last_Updated_At, Last_Updated_By)
						VALUES (@mid, @vm_name, @vminstance_size_id, @image_name, @location_id, @vm_request_status, CURRENT_TIMESTAMP, @mid)
	SET @id = SCOPE_IDENTITY()
	IF (@id != 0)
		BEGIN
			INSERT INTO VM_Request_StatusUpdate (Request_Id, VM_Request_Status_Id, Updated_By, Updated_At)
							VALUES (@id, @vm_request_status_id, @mid, CURRENT_TIMESTAMP)
			IF (@@ROWCOUNT = 1)
			BEGIN
				SET @result = 'Success'
			END
		END
END