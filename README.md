# Etec.Bd.Sorteio

## Requirements

- Microsoft .NET 7 SDK
- Microsoft SQL Server
- Docker (optional)

## Development use

- Clone this repo
- Initialize SQL Server with
```bash
docker pull mcr.microsoft.com/mssql/server:2017-latest &&
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=*123456HAS*" -p 1433:1433 --name sqlhas --hostname sqlhas -d mcr.microsoft.com/mssql/server:2017-latest
```
- Run the `db.sql` file
- Run the command on root folder `dotnet run`
- Open in your browser in `localhost:5096` (dev mode)
