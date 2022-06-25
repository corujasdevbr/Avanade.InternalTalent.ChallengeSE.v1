# Avanade.InternalTalent.ChallengeSE.v1

# DESAFIO

- Criar uma API para fazer um CRUD ( o CRUD mais lindo da vida)
Deve haver os seguintes pre requisitos:
 - Utilizar os seguintes tipos primitivos (int, bool, datetime, string, arrays (Lista ou Coleções))
 - Ter 1 exemplo de cada pilar de OOP
 - Ter 1 exemplo de Design Pattern (Criação, Comportamento ou estrutura)
 - Ter um relacionamento entre os objetos (1:1 ou 1:n ou n:n)
 - Utilizar um ORM
 - Ter um teste de unidade 
 - Utlizar o Swagger para documentar a API
 - Criar um README.md
 - 
 * Código precisa estar versionado no Github
 * Precisa estar fazendo o build através do Github Actions (Continuos Integration)
 * Utilizar Conventional Commits

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

https://github.com/jbogard/MediatR

https://www.nuget.org/packages/Canducci.Pagination/

https://automapper.org/
