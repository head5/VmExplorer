CREATE TABLE [dbo].[Users] (
    [MId]      VARCHAR (11) NOT NULL,
    [Domain]   VARCHAR (25) NOT NULL,
    [UserName] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Admin]    CHAR (1)     DEFAULT ('N') NOT NULL,
    [Active]   CHAR (1)     DEFAULT ('Y') NOT NULL,
    PRIMARY KEY CLUSTERED ([MId] ASC)
);