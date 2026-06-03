From mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish GerenciadorDeUsuarios.API/GerenciadorDeUsuarios.API.csproj -c Release -o /app/publish

From mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "GerenciadorDeUsuarios.API.dll"]
