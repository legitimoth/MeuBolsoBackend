# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copia o arquivo de solução e o .csproj do projeto
COPY MeuBolso.sln ./
COPY ./Api/*.csproj ./Api/

# Restaura as dependências
RUN dotnet restore

# Copia o restante do código
COPY . ./

# Publica a aplicação
RUN dotnet publish -c Release -o out

# Etapa 2: Imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expor as portas HTTP e HTTPS dentro do container
EXPOSE 8080

# Rodar a aplicação
ENTRYPOINT ["dotnet", "MeuBolso.Api.dll"]