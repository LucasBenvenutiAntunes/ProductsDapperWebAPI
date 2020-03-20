CREATE TABLE [dbo].[Products] (
    [ProductId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Price]     FLOAT (53)     NOT NULL,
    [Created]   NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ProductId] DESC)
);

