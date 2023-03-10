FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CineMoviesWeb/CineMoviesWeb.csproj", "CineMoviesWeb/"]
RUN dotnet restore "CineMoviesWeb/CineMoviesWeb.csproj"
COPY . .
WORKDIR "/src/CineMoviesWeb"
RUN dotnet build "CineMoviesWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CineMoviesWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CineMoviesWeb.dll"]
