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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE TABLE [Clients] (
        [ClientId] int NOT NULL IDENTITY,
        [ClientName] nvarchar(max) NOT NULL,
        [Currency] nvarchar(max) NOT NULL,
        [BillingMethod] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE TABLE [Designations] (
        [DesignationId] int NOT NULL IDENTITY,
        [DesignationName] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Designations] PRIMARY KEY ([DesignationId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE TABLE [Projects] (
        [ProjectId] int NOT NULL IDENTITY,
        [ProjectName] nvarchar(max) NOT NULL,
        [ClientId] int NOT NULL,
        [ProjectCost] int NOT NULL,
        [ProjectHeadId] int NOT NULL,
        [ProjectManagerId] int NOT NULL,
        [ProjectUserId] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Projects] PRIMARY KEY ([ProjectId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE TABLE [ProjectUsers] (
        [ProjectUsersId] int NOT NULL IDENTITY,
        [ProjectId] int NOT NULL,
        [UserId] int NOT NULL,
        [IsDeleted] bit NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_ProjectUsers] PRIMARY KEY ([ProjectUsersId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE TABLE [UserRoles] (
        [UserRoleId] int NOT NULL IDENTITY,
        [RoleName] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [IsDeleted] bit NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserRoleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [UserRoleId] int NOT NULL,
        [DesignationId] int NULL,
        [EmpId] int NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [FullName] nvarchar(max) NOT NULL,
        [EmailId] nvarchar(max) NOT NULL,
        [PhoneNumber] int NOT NULL,
        [IsActive] bit NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedBy] int NULL,
        [UpdatedDate] datetime2 NULL,
        [UpdatedBy] int NULL,
        [UserRolesRolesUserRoleId] int NOT NULL,
        [DesignationsDesignationId] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
        CONSTRAINT [FK_Users_Designations_DesignationsDesignationId] FOREIGN KEY ([DesignationsDesignationId]) REFERENCES [Designations] ([DesignationId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Users_UserRoles_UserRolesRolesUserRoleId] FOREIGN KEY ([UserRolesRolesUserRoleId]) REFERENCES [UserRoles] ([UserRoleId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE INDEX [IX_Users_DesignationsDesignationId] ON [Users] ([DesignationsDesignationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    CREATE INDEX [IX_Users_UserRolesRolesUserRoleId] ON [Users] ([UserRolesRolesUserRoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230421135802_TimeSheetsMgmtProjectData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230421135802_TimeSheetsMgmtProjectData', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Designations_DesignationsDesignationId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_UserRoles_UserRolesRolesUserRoleId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    DROP INDEX [IX_Users_DesignationsDesignationId] ON [Users];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    DROP INDEX [IX_Users_UserRolesRolesUserRoleId] ON [Users];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'DesignationsDesignationId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Users] DROP COLUMN [DesignationsDesignationId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'UserRolesRolesUserRoleId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Users] DROP COLUMN [UserRolesRolesUserRoleId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'DesignationId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var2 + '];');
    EXEC(N'UPDATE [Users] SET [DesignationId] = 0 WHERE [DesignationId] IS NULL');
    ALTER TABLE [Users] ALTER COLUMN [DesignationId] int NOT NULL;
    ALTER TABLE [Users] ADD DEFAULT 0 FOR [DesignationId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Clients] ADD [EmailId] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Clients] ADD [Fax] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Clients] ADD [FirstName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Clients] ADD [LastName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Clients] ADD [Mobile] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    ALTER TABLE [Clients] ADD [Phone] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509154818_datatimesheet')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230509154818_datatimesheet', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515101822_datatimesheetmgmt')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'BillingMethod');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Clients] DROP COLUMN [BillingMethod];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515101822_datatimesheetmgmt')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'Currency');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Clients] DROP COLUMN [Currency];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515101822_datatimesheetmgmt')
BEGIN
    ALTER TABLE [Projects] ADD [Rate] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515101822_datatimesheetmgmt')
BEGIN
    ALTER TABLE [Clients] ADD [BillingMethodId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515101822_datatimesheetmgmt')
BEGIN
    ALTER TABLE [Clients] ADD [CurrencyId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515101822_datatimesheetmgmt')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230515101822_datatimesheetmgmt', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230515130748_errorchangesnew')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230515130748_errorchangesnew', N'7.0.5');
END;
GO

COMMIT;
GO

