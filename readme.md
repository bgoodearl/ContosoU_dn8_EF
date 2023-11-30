# Contoso University EF Core 8

ASP.NET 8 Entity Framework Core 8 - demo of EF Core 8

The code for the starting point of this endeavour can be found
[in GitHub here](https://github.com/bgoodearl/ContosoU_dn6_MVCB_Clean).

## Developer Notes

[Dev Notes](./_docs/CC6__DevNotes.md)<br/>

## IMPORTANT NOTES

### Initial setup after cloning repo or getting code in zip

Create your local database(es) and use the SQL scripts:<br/>
`...\SqlScripts\Schema\CU6_M01_ExistingSchemaBase_2022_idempotent.sql`<br/>
`...\SqlScripts\Schema\CU6_M02_AddEnrollment_idempotent.sql`<br/>
to create the tables for the database used for migrations.<br/>

Use the SQL scripts:<br/>
`...\SqlScripts\Schema\CU6_M01_ExistingSchemaBase_2022.sql`<br/>
`...\SqlScripts\Schema\CU6_M02_AddEnrollment.sql`<br/>
`...\SqlScripts\Schema\CU6_M03_AddCourseInstructorLink.sql`<br/>
to create the tables for the database used for integration tests and the web app.<br/>

Copy `...\_ConfigSource\src\ContosoUniversity\appsettings.Development_user_xxxx.json`
to `...\src\ContosoUniversity` replacing "xxxx" in the file name with the 
username of the account from which you are running Visual Studio, and
update the paths in the file to match your solution path.  Also,
and correct connection string for your environment.

Update paths for `internalLogFile` and `var_logdir`
in `appsettings.Development_user_...` after you copy and rename it.

Copy `...\_ConfigSource\src\CU.EFDataApp\appsettings.migrations.json`
to `...\src\CU.EFDataApp` and modify connection string for your environment.

Copy `...\_ConfigSource\src\tests\CU.ApplicationIntegrationTests\appsettings.LocalTesting.json`
to `...\src\tests\CU.ApplicationIntegrationTests` and modify connection string for your environment.

## Resource links

--- needs to be updated

### Seeding Data

Set connection string in ...\src\tests\CU.ApplicationIntegrationTests\appsettings.LocalTesting.json
for the database you want to seed.

Run a single test that uses GetISchoolDbContext (e.g. CanGetCoursesAsync()).

See code in TestFixture.GetISchoolDbContext(ITestOutputHelper testOutputHelper) for more information.

## Projects

Project Name                    | Description
-------------                   | ------------
ContosoUniversity.Models        | Persistent Data Object Models (Domain)
CU.Application.Common           | Interfaces allowing use of the Repository
CU.Application.Data.Common      | Interface for DbContext
CU.Application.Shared           | Interfaces and Classes shared among multiple CU projects
CU.Definitions                  | consts - starting with lookup codes
CU.EFDataApp                    | Web app used when running migrations
CU.Infrastructure               | Infrastructure, including Entity Framework DbContext, Repositories, and Migrations
CU.SharedKernel                 | Classes shared among multiple app projects
.                               |
CU.ApplicationIntegrationTests  | Application integration tests

