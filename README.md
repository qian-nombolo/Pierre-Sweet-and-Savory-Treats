# Pierre's Sweet and Savory Treats

#### By _Qian Li_  😊

#### This is my c# and .NET project which builds an application with user authentication and a many-to-many relationship to market sweet and savory treats.

## Technologies Used

* C#
* .NET
* HTML
* MVC
* Entity Framework
* MySQL Workbench
* VS code

## Description

* A user should be able to log in and log out. Only logged in users have create, update, and delete functionality. All users should be able to have read functionality. 
* A user should be able to navigate to a splash page that lists all treats and flavors. Users are able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Setup/Installation Requirements

* _Clone “Pierre-Sweet-and-Savory-Treats
“ from the repository to your desktop_.
* _Navigate to "Pierre-Sweet-and-Savory-Treats
" directory via your local terminal command line_.
* Run the app, first navigate to this project's production directory called "SweetSavoryTreats". 
* Run `dotnet restore` to restore all the packages.
* Add appsettings.json file, please see the "Database Connection String Setup" instruction below.
* Create the database using the migrations in the "SweetSavoryTreats" project. Open your shell (e.g., Terminal or GitBash) to the production directory "FantacyRecipe", and `run dotnet ef database update`.
* Within the production directory "SweetSavoryTreats", run `dotnet watch run` in the command line to start the project in development mode with a watcher.
* Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Database Connection String Setup 

* Create an appsetting.json file in the "SweetSavoryTreats" directory of the project. The example is below.
* Within appsettings.json, put in the following code, replacing the uid and pwd values with your own username and password for MySQL Workbench.

```
Pierre-Sweet-and-Savory-Treats/SweetSavoryTreats/appsettings.json

 {
    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;
      database=[Your-DATA-BASE];uid=[YOUR-USER-HERE];
      pwd=[YOUR-PASSWORD-HERE];"
    }
 }
```

## Known Bugs

No bugs 

## License
[MIT](license.txt)
Copyright (c) 2023 Qian Li

