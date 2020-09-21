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


## Features

- WebApi
- JWT Token
- Core Api (keep cache user credenditals sending trough api's)
- Microservices
- User Gravatar
- Entity Framework Core
- Jquery
- Custom Validations
- Summary Validations

## Future Implementations

- CQRS using Mediator
- Commands
- Events
- Queries

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2020 © <a href="http://renancamara.com" target="_blank">Renan Camara</a>.
