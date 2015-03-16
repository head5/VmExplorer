CREATE TABLE [dbo].[VM_Request_StatusUpdate] (
    [VM_Req_Status_Update_Id] INT          IDENTITY (1, 1) NOT NULL,
    [Request_Id]              INT          NOT NULL,
    [VM_Request_Status_Id]    INT          NOT NULL,
    [Updated_By]              VARCHAR (11) NULL,
    [Updated_At]              DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([VM_Req_Status_Update_Id] ASC)
);