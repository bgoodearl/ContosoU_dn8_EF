USE ContosoUniversity22; --Database used for tests
GO
BEGIN TRANSACTION;
GO

ALTER TABLE [OfficeAssignment] ADD [OBLTId] smallint NULL;
GO

ALTER TABLE [OfficeAssignment] ADD [OfficeBuildingCode] nvarchar(2) NULL;
GO

CREATE INDEX [IX_OfficeAssignment_OBLTId_OfficeBuildingCode] ON [OfficeAssignment] ([OBLTId], [OfficeBuildingCode]);
GO

ALTER TABLE [OfficeAssignment] ADD CONSTRAINT [FK_OfficeAssignment_xLookups2cKey_OBLTId_OfficeBuildingCode] FOREIGN KEY ([OBLTId], [OfficeBuildingCode]) REFERENCES [xLookups2cKey] ([LookupTypeId], [Code]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231208153219_CU6_M05_AddLookups2', N'6.0.20');
GO

COMMIT;
GO

