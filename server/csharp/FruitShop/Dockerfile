FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FruitShop/FruitShop.csproj", "FruitShop/"]
RUN dotnet restore "FruitShop/FruitShop.csproj"
COPY . .
WORKDIR "/src/FruitShop"
RUN dotnet build "FruitShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FruitShop.csproj" -c Release -o /app/publish

FROM base AS final
EXPOSE 5173
EXPOSE 7189

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FruitShop.dll"]
