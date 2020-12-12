IF NOT EXISTS (SELECT *
FROM sys.databases
WHERE name = 'WorldLinkDB')
    BEGIN
    CREATE DATABASE [WorldLinkDB];
END
    GO

IF EXISTS (SELECT *
FROM sys.databases
WHERE name = 'WorldLinkDB')
    USE [WorldLinkDB]
    GO

SET ANSI_NULLS ON
    GO

SET QUOTED_IDENTIFIER ON
    GO


CREATE TABLE [dbo].[Tb_Contato]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (MAX) NOT NULL,
    [Email] NVARCHAR (MAX) NOT NULL
);

CREATE TABLE [dbo].[Tb_Usuario]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (MAX) NOT NULL,
    [Senha] NVARCHAR (MAX) NOT NULL
);
