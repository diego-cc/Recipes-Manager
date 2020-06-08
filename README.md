# Recipes Manager
A desktop application dedicated to hard-working chefs who wish to manage their recipes, ingredients, quantities, etc. Developed for an assignment at North Metropolitan TAFE.

Built with WPF (MVVM), using MSSQL localDB for storage and [FluentWPF](https://github.com/sourcechord/FluentWPF "FluentWPF") for basic styles.

# Instructions
The application should work out of the box. See the [releases](https://github.com/diego-cc/Recipes-Manager/releases "Releases") page to download the latest version containing the executable.

## (Optional) Seed data
If you wish to create the database and seed data in advance (which slightly improves the initial [freeze](https://github.com/diego-cc/Recipes-Manager/issues/2) of the application), follow the steps below:

### 1 - Clone the repository
Run `git clone https://github.com/diego-cc/Recipes-Manager.git`

### 2 - Open in Visual Studio
Double-click the [`RecipesManager.sln`](https://github.com/diego-cc/Recipes-Manager/blob/master/RecipesManager/RecipesManager.sln) solution file to open the project in Visual Studio.

### 3 - Create and seed database
Open the Package Manager console (Tools > NuGet Package Manager > Package Manager Console), change the default project to __RecipesData__ and run:

`Update-Database`

This command applies all pending migrations (or creates a new database, if it doesn't exist yet) and seeds data from the [Configuration](https://github.com/diego-cc/Recipes-Manager/blob/master/RecipesData/Migrations/Configuration.cs "Configuration") file.

Now that data should be readily available after you start the application.
