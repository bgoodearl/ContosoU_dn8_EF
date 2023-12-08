# Contoso University Clean 6 - Migration Notes

## EF Core docs

[Managing Database Schemas](https://docs.microsoft.com/en-us/ef/core/managing-schemas/)
(c. Sep 2020)<br/>

[Additional EF Core 6 resource links](../../_docs/CC6_EFCore6Resources.md)<br/>

## Migrations

Before running any migrations, copy appSettings.migrations.json from
`...\_configSource\src\CU.EFDataApp`
to `...\src\CU.EFDataApp` and update the connection string to point to
the test database used for building migrations.

### .NET EF Core 6 Package Manager Console

[Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://docs.microsoft.com/en-us/ef/core/cli/powershell)

```powershell
get-help about_EntityFrameworkCore
```

Quick check of environment for Package Manager Console
```powershell
Get-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp
```
(add -verbose to the end of the command above to confirm the correct database and server)

### Remove Migration
```powershell
Remove-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp
```

### First Migration

#### CU6_M01_ExistingSchemaBase_2022

```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M01_ExistingSchemaBase_2022
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From 0 -To CU6_M01_ExistingSchemaBase_2022 -output .\SqlScripts\Schema\CU6_M01_ExistingSchemaBase_2022_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From 0 -To CU6_M01_ExistingSchemaBase_2022 -output .\SqlScripts\Schema\CU6_M01_ExistingSchemaBase_2022.sql
```

### Additional Migrations

#### CU6_M02_AddEnrollment

```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M02_AddEnrollment
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M01_ExistingSchemaBase_2022 -To CU6_M02_AddEnrollment -output .\SqlScripts\Schema\CU6_M02_AddEnrollment_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M01_ExistingSchemaBase_2022 -To CU6_M02_AddEnrollment -output .\SqlScripts\Schema\CU6_M02_AddEnrollment.sql
```

#### CU6_M03_AddCourseInstructorLink

```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M03_AddCourseInstructorLink
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M02_AddEnrollment -To CU6_M03_AddCourseInstructorLink -output .\SqlScripts\Schema\CU6_M03_AddCourseInstructorLink_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M02_AddEnrollment -To CU6_M03_AddCourseInstructorLink -output .\SqlScripts\Schema\CU6_M03_AddCourseInstructorLink.sql
```

#### CU6_M04_AddLookups

```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M04_AddLookups
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M03_AddCourseInstructorLink -To CU6_M04_AddLookups -output .\SqlScripts\Schema\CU6_M04_AddLookups_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M03_AddCourseInstructorLink -To CU6_M04_AddLookups -output .\SqlScripts\Schema\CU6_M04_AddLookups.sql
```

#### CU6_M05_AddLookups2

```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M05_AddLookups2
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M04_AddLookups -To CU6_M05_AddLookups2 -output .\SqlScripts\Schema\CU6_M05_AddLookups2_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M04_AddLookups -To CU6_M05_AddLookups2 -output .\SqlScripts\Schema\CU6_M05_AddLookups2.sql
```

### What's in Migrations

Migration                       | Details
-------------                   | ------------
CU6_M01_ExistingSchemaBase_2022 | match for base of existing schema from prior implementation w/.NET Core 3.1 WITHOUT Enrollments or Courses -- Instructors
CU6_M02_AddEnrollment           | added Enrollment table with links to Course and Student
CU6_M03_AddCourseInstructorLink | added many-to-many link between Course and Instructor
CU6_M04_AddLookups              | added 2 lookup types with single table xLookups2cKey
CU6_M05_AddLookups2             | added lookup OfficeBuilding

