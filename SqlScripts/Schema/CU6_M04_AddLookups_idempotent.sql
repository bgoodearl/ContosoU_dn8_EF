USE ContosoU_dn6_dev; --Database used for Migrations
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE TABLE [xLookups2cKey] (
        [Code] nvarchar(2) NOT NULL,
        [LookupTypeId] smallint NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [_SubType] smallint NOT NULL,
        CONSTRAINT [PK_xLookups2cKey] PRIMARY KEY ([LookupTypeId], [Code])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE TABLE [xLookupTypes] (
        [Id] smallint NOT NULL,
        [TypeName] nvarchar(50) NOT NULL,
        [BaseTypeName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_xLookupTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE TABLE [_coursesPresentationTypes] (
        [CourseID] int NOT NULL,
        [LookupTypeId] smallint NOT NULL,
        [CoursePresentationTypeCode] nvarchar(2) NOT NULL,
        CONSTRAINT [PK__coursesPresentationTypes] PRIMARY KEY ([CourseID], [LookupTypeId], [CoursePresentationTypeCode]),
        CONSTRAINT [FK__coursesPresentationTypes_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([CourseID]) ON DELETE CASCADE,
        CONSTRAINT [FK__coursesPresentationTypes_xLookups2cKey_LookupTypeId_CoursePresentationTypeCode] FOREIGN KEY ([LookupTypeId], [CoursePresentationTypeCode]) REFERENCES [xLookups2cKey] ([LookupTypeId], [Code]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE TABLE [_departmentsFacilityTypes] (
        [DepartmentID] int NOT NULL,
        [LookupTypeId] smallint NOT NULL,
        [DepartmentFacilityTypeCode] nvarchar(2) NOT NULL,
        CONSTRAINT [PK__departmentsFacilityTypes] PRIMARY KEY ([DepartmentID], [LookupTypeId], [DepartmentFacilityTypeCode]),
        CONSTRAINT [FK__departmentsFacilityTypes_Department_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE CASCADE,
        CONSTRAINT [FK__departmentsFacilityTypes_xLookups2cKey_LookupTypeId_DepartmentFacilityTypeCode] FOREIGN KEY ([LookupTypeId], [DepartmentFacilityTypeCode]) REFERENCES [xLookups2cKey] ([LookupTypeId], [Code]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE INDEX [IX__coursesPresentationTypes_LookupTypeId_CoursePresentationTypeCode] ON [_coursesPresentationTypes] ([LookupTypeId], [CoursePresentationTypeCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE INDEX [IX__departmentsFacilityTypes_LookupTypeId_DepartmentFacilityTypeCode] ON [_departmentsFacilityTypes] ([LookupTypeId], [DepartmentFacilityTypeCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    CREATE UNIQUE INDEX [LookupTypeAndName] ON [xLookups2cKey] ([LookupTypeId], [Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231130200813_CU6_M04_AddLookups')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231130200813_CU6_M04_AddLookups', N'6.0.20');
END;
GO

COMMIT;
GO

