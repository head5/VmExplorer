CREATE TABLE [dbo].[VM_Request_Status] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Status] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
