CREATE TABLE [dbo].[Location] (
    [LocationId] INT          IDENTITY (1, 1) NOT NULL,
    [Location]   VARCHAR (25) NOT NULL,
    [IsValid]    CHAR (1)     DEFAULT ('Y') NOT NULL,
    PRIMARY KEY CLUSTERED ([LocationId] ASC)
);