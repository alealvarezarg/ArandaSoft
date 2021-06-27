IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Rolname] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Lastname] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [RolId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Users_RolId] ON [Users] ([RolId]);
GO

SET IDENTITY_INSERT [dbo].[Roles] ON;
                INSERT INTO [dbo].[Roles] ([Id], [Rolname], [Description]) VALUES (1, N'Administrador', N'Rol de administrador');
                SET IDENTITY_INSERT [dbo].[Roles] OFF;
                SET IDENTITY_INSERT [dbo].[Users] ON;
                INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [Name], [Lastname], [Phone], [Email], [Age], [RolId]) VALUES (1, N'admon', N'123', N'Admin', N'Admin', N'3001001020', N'admon@arandasoft.com', 99, 1);
                SET IDENTITY_INSERT [dbo].[Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210627214451_InitialMigration', N'6.0.0-preview.5.21301.9');
GO

COMMIT;
GO

