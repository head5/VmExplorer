CREATE TABLE [dbo].[VM_Instance_Size] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (15) NOT NULL,
    [Memory] VARCHAR (15) NOT NULL,
    [Core]   VARCHAR (25) NOT NULL,
    [Active] CHAR (1)     DEFAULT ('Y') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);