# PROJECT LYRIC.BACKEND

## Requirements

For development, You will need to install .net core installed on your enviornment


### Commands to start new .net core web api project

    dotnet new webapi
    dotnet restore
    dotnet run
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    follow this to add entity framework to .net core 
    https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db

### EF Migrations

    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet
    http://www.learnentityframeworkcore.com/migrations => migrating db

    dotnet ef migrations remove
    dotnet ef migrations add "initial migration"
    dotnet ef database update

### To Add Package

    dotnet add packge <packagename>


### AUTHENTICATIO CONFIGURE

    https://github.com/TahirNaushad/Fiver.Security.Bearer.git

## Deploy staging

```
virtualenv venv_deploy -p python2
source venv_deploy/bin/activate
pip install -r requirements.txt
fab -f fab.py deploy_staging
```
