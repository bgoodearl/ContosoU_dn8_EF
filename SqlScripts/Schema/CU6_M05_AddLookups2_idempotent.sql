--USE ContosoU_dn6_dev; --Database used for Migrations
--USE ContosoU_dn6_dev2; --Database used for Migrations
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208153219_CU6_M05_AddLookups2')
BEGIN
    ALTER TABLE [OfficeAssignment] ADD [OBLTId] smallint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208153219_CU6_M05_AddLookups2')
BEGIN
    ALTER TABLE [OfficeAssignment] ADD [OfficeBuildingCode] nvarchar(2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208153219_CU6_M05_AddLookups2')
BEGIN
    CREATE INDEX [IX_OfficeAssignment_OBLTId_OfficeBuildingCode] ON [OfficeAssignment] ([OBLTId], [OfficeBuildingCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208153219_CU6_M05_AddLookups2')
BEGIN
    ALTER TABLE [OfficeAssignment] ADD CONSTRAINT [FK_OfficeAssignment_xLookups2cKey_OBLTId_OfficeBuildingCode] FOREIGN KEY ([OBLTId], [OfficeBuildingCode]) REFERENCES [xLookups2cKey] ([LookupTypeId], [Code]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231208153219_CU6_M05_AddLookups2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231208153219_CU6_M05_AddLookups2', N'6.0.20');
END;
GO

COMMIT;
GO

