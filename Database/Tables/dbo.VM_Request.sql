CREATE TABLE [dbo].[VM_Request] (
    [Request_Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Mid]                 VARCHAR (11)  NOT NULL,
    [VMName]              VARCHAR (20)  NOT NULL,
    [Password]            VARCHAR (50)  NULL,
    [RDPPath]             VARCHAR (50)  NULL,
    [VM_Instance_Size_Id] INT           NOT NULL,
    [Image_Name]          VARCHAR (MAX) NOT NULL,
    [LocationId]          INT           NOT NULL,
    [Current_Status]      VARCHAR (10)  NULL,
    [Last_Updated_At]     DATETIME      NULL,
    [Last_Updated_By]     VARCHAR (11)  NULL,
    PRIMARY KEY CLUSTERED ([Request_Id] ASC)
);