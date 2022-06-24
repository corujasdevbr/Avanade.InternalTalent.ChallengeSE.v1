# Avanade.InternalTalent.ChallengeSE.v1

Links utilizados para a contrução da API

0. Para criar esse documento

https://www.markdownguide.org/extended-syntax/

1. Para a arquitetura

https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures
https://docs.microsoft.com/pt-br/azure/architecture/patterns/cqrs

2. Para a controller

https://developer.mozilla.org/en-US/docs/Web/HTTP/Status

https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0


3. Para a camada de repositorio

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

https://docs.microsoft.com/en-us/ef/core/modeling/

4. Docker

https://www.docker.com/

5. Comandos

Para criar o banco de dados usando o Docker no WSL2

```
docker run --name sqlserver --hostname sqlserver -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<yourStrong@Password>" -e MSSQL_PID=Developer -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU16-GDR1-ubuntu-20.04
```

Para criar o banco de dados utilizando o Migrations

```
add-migration Initial_Database
```
Para efetivar a alteração no banco de dados

```
update-database
```

Para criar outras migrations, caso o modelo seja alterado

```
add-migration <name>
```

6. Bibliotecas

https://dotnetcoretutorials.com/2019/04/30/the-mediator-pattern-in-net-core-part-1-whats-a-mediator/

https://www.nuget.org/packages/Canducci.Pagination/
