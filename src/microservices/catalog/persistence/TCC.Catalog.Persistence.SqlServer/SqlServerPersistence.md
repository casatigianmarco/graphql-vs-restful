# TCC.Catalog.Persistence.SqlServer
É a livraria que contem as configuracões do banco de dados e as migraćões.

Será utilizado o patter Code First por meio da lib .NET EntityFrameworkCore

# Pre-requisitos
- https://hub.docker.com/_/microsoft-mssql-server
- docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pa55w0rd' -p 1433:1433 -d --name mssqltcc microsoft/mssql-server-linux
- docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=local-dev-p4$$w0Rd" -p 1433:1433 -d --name mssqltcc --hostname sqltcc mcr.microsoft.com/mssql/server:2022-latest
- dotnet tool install --global dotnet-ef

# Criar a primeira migration
```bash
cd TCC.Catalog.Persistence.SqlServer
dotnet ef migrations add <MigrationName>
```

# Atualizar o banco de dados
```bash
cd TCC.Catalog.Persistence.SqlServer
dotnet ef migrations update <MigrationName>
```