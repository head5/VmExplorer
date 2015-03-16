CREATE PROCEDURE [dbo].[CancelVMRequest]
	@request_id int,
	@mid varchar(11),
	@vm_request_status varchar(10),
	@vm_request_status_id int,
	@result varchar(25) OUTPUT
AS
BEGIN
	SET @result = 'Fail'
	UPDATE VM_Request
		SET 
			Current_Status = @vm_request_status,
			Last_Updated_At = CURRENT_TIMESTAMP,
			Last_Updated_By = @mid
		WHERE VM_Request.Request_Id = @request_id

		IF (@@ROWCOUNT != 0)
		BEGIN
			INSERT INTO VM_Request_StatusUpdate (Request_Id, VM_Request_Status_Id, Updated_By, Updated_At)
								 VALUES (@request_id, @vm_request_status_id, @mid, CURRENT_TIMESTAMP)
			IF (@@ROWCOUNT = 1)
			BEGIN
				SET @result = 'Success'
			END
		END
END