CREATE DATABASE [TesteTecnicoKNEWIN];
IF SERVERPROPERTY('EngineEdition') <> 5 BEGIN ALTER DATABASE [TesteTecnicoKNEWIN]
SET READ_COMMITTED_SNAPSHOT ON;
END;
SELECT 1 CREATE TABLE [__EFMigrationsHistory] (
    [MigrationId] nvarchar(150) NOT NULL,
    [ProductVersion] nvarchar(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
  );
SELECT 1
SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
SELECT [MigrationId],
  [ProductVersion]
FROM [__EFMigrationsHistory]
ORDER BY [MigrationId];
CREATE TABLE [Users] (
  [Id] int NOT NULL IDENTITY,
  [Name] nvarchar(max) NOT NULL,
  [Email] nvarchar(max) NOT NULL,
  CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
CREATE TABLE [Posts] (
  [Id] int NOT NULL IDENTITY,
  [UserId] int NOT NULL,
  [PublicationDate] datetime2 NOT NULL,
  [Title] nvarchar(max) NOT NULL,
  [Content] nvarchar(max) NOT NULL,
  CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
CREATE INDEX [IX_Posts_UserId] ON [Posts] ([UserId]);
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220818164730_FirstMigration', N'6.0.8');
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220819074754_final_migration', N'6.0.8');