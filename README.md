# WhereIsMyGame
With this simple solution you can track where your game is, how long, who did not returned it.

![Logo](https://github.com/rcamara32/WhereIsMyGame/blob/master/docs/images/logo_big.png)

## Create Database

Run the command to generate the migration files:

```
dotnet ef database update --context ApplicationDbContext --project \WhereIsMyGame\src\WhereIsMyGame.API.Auth\WhereIsMyGame.Auth.API.csproj
```

Run the command to generate the database:

```
dotnet ef database update --context CollectionContext --project \WhereIsMyGame\src\WhereIsMyGame.Collection.API\WhereIsMyGame.Collection.API.csproj
```

## Populating Plafatorm Table
run this file on t-SQL
https://github.com/rcamara32/WhereIsMyGame/blob/master/SQL/01%20-%20INSERT%20PLATAFORMS.sql
