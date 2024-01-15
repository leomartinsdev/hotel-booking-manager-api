FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet HotelManagerAPI.dll

# Se quiser rodar a aplicação localmente, você pode usar a linha abaixo e remover
# o comando CMD acima.
#ENTRYPOINT ["dotnet", "HotelManagerAPI.dll"]