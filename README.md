# Areas-MVC

Initial steps to follow before start project into local system:

Web.config file change connection string to your system.

Update database Update-Database -Configuration UdemyMVC.CompanyMigration.Configuration Update-Database -Configuration UdemyMVC.IdentityMigrations.Configuration

Description of project :

This project demonstrates diffrent Areas in MVC (eg. Admin, Manager and Customer) and according rights for CRUD with respect of diffrent Areas. Ajax and WebApi used in Admin->Brands. InCase if you change any models then you need to update database by following commands:

Enable-Migrations -ContextTypeName UdemyMVC.Identity.ApplicationDbContext -MigrationsDirectory IdentityMigrations
Add-Migration -Configuration UdemyMVC.IdentityMigrations.Configuration Initial01
Update-Database -Configuration UdemyMVC.IdentityMigrations.Configuration
